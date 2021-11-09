using DDD.Base.Domain;
using PhotoStock.SharedKernel;
using System.Collections.Generic;

namespace PhotoStock.Sales.Contract.Events
{
  public class OrderConfirmedEvent : Event
  {
    public AggregateId OrderId { get; private set; }
    public ClientData ClientData { get; private set; }
    public IEnumerable<OrderItem> Items { get; private set; }

    public OrderConfirmedEvent(AggregateId orderId, ClientData clientData, IEnumerable<OrderItem> items)
    {
      OrderId = orderId;
      ClientData = clientData;
      Items = items;
    }
  }
}
  