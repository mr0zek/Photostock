using DDD.Base.Domain;
using DDD.Base.SharedKernel;
using PhotoStock.Sales.Domain.Offer;
using PhotoStock.Sales.Domain.Offer.Discount;
using PhotoStock.Sales.Domain.ProductsCatalog;
using PhotoStock.SharedKernel;
using System.Collections.Generic;

namespace PhotoStock.Sales.Domain.Reservation
{
  public class Reservation : AggregateRoot
  {
    public enum ReservationStatus
    {
      OPENED,
      CLOSED
    };

    private ReservationStatus _status;
    private ISet<ReservationItem> _items;
    private AggregateId _clientId;
    private Date _createDate;
    private IProductRepository _productRepository;

    protected Reservation()
    {
    }

    internal Reservation(AggregateId reservationId, ReservationStatus status, AggregateId clientId, Date createDate, IProductRepository productRepository) : base(reservationId)
    {
      _status = status;
      _clientId = clientId;
      _createDate = createDate;
      _productRepository = productRepository;
      _items = new HashSet<ReservationItem>();
    }

    public void Add(Product product)
    {
      if (IsClosed())
        DomainError("Reservation already closed");

      _items.Add(new ReservationItem(product.AggregateId));
    }

    public bool IsClosed()
    {
      return _status == ReservationStatus.CLOSED;
    }

    public void Close()
    {
      if (IsClosed())
      {
        DomainError("Reservation is already closed");
      }
      _status = ReservationStatus.CLOSED;
    }

    public Offer.Offer CalculateOffer(IDiscountPolicy discountPolicy)
    {
      List<OfferItem> availabeItems = new List<OfferItem>();
      List<OfferItem> unavailableItems = new List<OfferItem>();

      Money totalCost = 0;
      foreach (ReservationItem item in _items)
      {
        Product product = _productRepository.Load(item.ProductId);
        if (product.CanBeSold())
        {
          totalCost += product.Price;
        }
      }

      foreach (ReservationItem item in _items)
      {
        Product product = _productRepository.Load(item.ProductId);
        if (product.CanBeSold())
        {
          Discount discount = discountPolicy.ApplyDiscount(product, product.Price, totalCost);
          OfferItem offerItem = new OfferItem(product.GenerateSnapshot(), discount);

          availabeItems.Add(offerItem);
        }
        else
        {
          OfferItem offerItem = new OfferItem(product.GenerateSnapshot());

          unavailableItems.Add(offerItem);
        }
      }

      return new Offer.Offer(_clientId, availabeItems, unavailableItems);
    }
  }
}