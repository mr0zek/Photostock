using DDD.Base.Domain;
using DDD.Base.SharedKernel;
using PhotoStock.Sales.Domain.ProductsCatalog;
using PhotoStock.SharedKernel;
using System;

namespace PhotoStock.Sales.Domain.Reservation
{
  public class ReservationFactory : IReservationFactory
  {
    private readonly IProductRepository _productCatalogRepository;
   
    private readonly IDomainEventPublisher _domainEventPublisher;

    public ReservationFactory(IProductRepository productCatalogRepository, IDomainEventPublisher domainEventPublisher)
    {
      _productCatalogRepository = productCatalogRepository;
      _domainEventPublisher = domainEventPublisher;
    }

    public Reservation Create(AggregateId orderId,Client.Client client)
    {
      var r =  new Reservation(
        orderId,
        Reservation.ReservationStatus.OPENED, 
        client.AggregateId, 
        Date.Today(), 
        _productCatalogRepository);
      _domainEventPublisher.Publish(new ReservationCreatedEvent(r.AggregateId, r.Version));
      return r;
    }
  }
}