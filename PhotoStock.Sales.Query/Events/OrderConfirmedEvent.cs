using System.Collections.Generic;
using DDD.Base.Domain;
using PhotoStock.SharedKernel;

namespace PhotoStock.Sales.Query.Events
{
  public class OrderConfirmedEvent 
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