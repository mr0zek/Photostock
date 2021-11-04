using DDD.Base.Domain;
using DDD.Base.SharedKernel.Specification;
using PhotoStock.Sales.Domain.Client;
using PhotoStock.Sales.Domain.Offer;
using PhotoStock.Sales.Domain.Offer.Discount;
using PhotoStock.Sales.Domain.ProductsCatalog;
using PhotoStock.Sales.Domain.Purchase;
using PhotoStock.Sales.Domain.Reservation;
using PhotoStock.System;

namespace PhotoStock.Sales.Application.Services.OrderingService
{

  public class OrderingService : IOrderingService
  {
    private ISystemContext _systemContext;
    private IClientRepository _clientRepository;
    private IReservationRepository _reservationRepository;
    private IReservationFactory _reservationFactory;
    private IPurchaseFactory _purchaseFactory;
    private IPurchaseRepository _purchaseRepository;
    private IProductRepository _productRepository;
    private IDiscountFactory _discountFactory;

    public OrderingService(
      ISystemContext systemContext,
      IClientRepository clientRepository,
      IReservationRepository reservationRepository,
      IReservationFactory reservationFactory,
      IPurchaseFactory purchaseFactory,
      IPurchaseRepository purchaseRepository,
      IProductRepository productRepository,
      IDiscountFactory discountFactory)
    {
      _systemContext = systemContext;
      _clientRepository = clientRepository;
      _reservationRepository = reservationRepository;
      _reservationFactory = reservationFactory;
      _purchaseFactory = purchaseFactory;
      _purchaseRepository = purchaseRepository;
      _productRepository = productRepository;
      _discountFactory = discountFactory;
    }

    public AggregateId CreateOrder()
    {
      Reservation reservation = _reservationFactory.Create(LoadClient());
      _reservationRepository.Save(reservation);
      return reservation.AggregateId;
    }

    public void AddPicture(AggregateId orderId, AggregateId pictureId)
    {
      Reservation reservation = _reservationRepository.Get(orderId);

      Product product = _productRepository.Get(pictureId);

      reservation.Add(product);

      _reservationRepository.Save(reservation);
    }

    public Offer CalculateOffer(AggregateId orderId)
    {
      Reservation reservation = _reservationRepository.Get(orderId);

      IDiscountPolicy discountPolicy = _discountFactory.Create(LoadClient());

      return reservation.CalculateOffer(discountPolicy);
    }

    //TODO: Transactions, dynamic proxy ?
    public void Confirm(AggregateId orderId, Offer seenOffer)
    {
      Reservation reservation = _reservationRepository.Get(orderId);
      Offer newOffer = reservation.CalculateOffer(_discountFactory.Create(LoadClient()));

      if (!newOffer.SameAs(seenOffer, 5))
      {
        throw new OfferChangedExcpetion(orderId, seenOffer, newOffer);
      }

      Client client = LoadClient();

      if (!client.CanAfford(newOffer.TotalCost))
      {
        throw new NotEnoughMoneyException(newOffer.TotalCost);
      }

      client.Charge(newOffer.TotalCost);
      _clientRepository.Save(client);

      Purchase purchase = _purchaseFactory.Create(orderId, client, newOffer);
      _purchaseRepository.Save(purchase);

      reservation.Close();
      _reservationRepository.Save(reservation);
    }

    private Client LoadClient()
    {
      return _clientRepository.Get(_systemContext.SystemUser.ClientId);
    }
  }
}