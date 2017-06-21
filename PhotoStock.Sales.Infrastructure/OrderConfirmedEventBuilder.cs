using DDD.Base.Domain;
using PhotoStock.Sales.Contract.Events;
using PhotoStock.Sales.Domain.Client;
using PhotoStock.Sales.Domain.Purchase;
using PhotoStock.SharedKernel;
using System.Collections.Generic;

namespace Photostock.Sales.Infrastructure
{
  internal class OrderConfirmedEventBuilder
  {
    private AggregateId _orderId;
    private ClientData _clientData;
    private IClientRepository _clientRepository;
    private List<OrderItem> _items = new List<OrderItem>();

    public OrderConfirmedEventBuilder(IClientRepository clientRepository)
    {
      _clientRepository = clientRepository;
    }

    public ISystemEvent Build()
    {
      return new OrderConfirmedEvent(_orderId, _clientData, _items);
    }
  }
}