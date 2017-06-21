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
    private IProductRepository _productRepository;

    public OrderingService(
      ISystemContext systemContext,
      IClientRepository clientRepository,
      IReservationRepository reservationRepository,
      IReservationFactory reservationFactory,
      IProductRepository productRepository)
    {
      _systemContext = systemContext;
      _clientRepository = clientRepository;
      _reservationRepository = reservationRepository;
      _reservationFactory = reservationFactory;      
      _productRepository = productRepository;
    }

    public AggregateId CreateOrder()
    {
      Reservation reservation = _reservationFactory.Create(LoadClient());
      _reservationRepository.Save(reservation);
      return reservation.AggregateId;
    }

    public void AddPicture(AggregateId orderId, AggregateId pictureId)
    {
      Reservation reservation = _reservationRepository.Load(orderId);

      Product product = _productRepository.Load(pictureId);

      reservation.Add(product);

      _reservationRepository.Save(reservation);
    }        

    private Client LoadClient()
    {
      return _clientRepository.Load(_systemContext.SystemUser.ClientId);
    }
  }
}