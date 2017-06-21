using DDD.Base.Domain;
using DDD.Base.SharedKernel.Specification;
using PhotoStock.Sales.Contract;
using PhotoStock.Sales.Domain.Client;
using PhotoStock.Sales.Domain.Offer;
using PhotoStock.Sales.Domain.Offer.Discount;
using PhotoStock.Sales.Domain.ProductsCatalog;
using PhotoStock.Sales.Domain.Purchase;
using PhotoStock.Sales.Domain.Reservation;
using PhotoStock.System;
using System;

namespace PhotoStock.Sales.Application.Services.OrderingService
{
  public class OrderingService : IOrderingService
  {
    private ISystemContext _systemContext;
    private IClientRepository _clientRepository;

    public OrderingService(
      ISystemContext systemContext,
      IClientRepository clientRepository)
    {
      _systemContext = systemContext;
      _clientRepository = clientRepository;
    }

    public AggregateId CreateOrder()
    {
      throw new NotImplementedException();
    }

    private Client LoadClient()
    {
      return _clientRepository.Load(_systemContext.SystemUser.ClientId);
    }
  }
}