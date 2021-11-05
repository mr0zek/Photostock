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

    public ReservationFactory(IProductRepository productCatalogRepository)
    {
      _productCatalogRepository = productCatalogRepository;
    }

    public Reservation Create(AggregateId orderId,Client.Client client)
    {
      return new Reservation(
        orderId,
        Reservation.ReservationStatus.OPENED, 
        client.AggregateId, 
        Date.Today(), 
        _productCatalogRepository);
    }
  }
}