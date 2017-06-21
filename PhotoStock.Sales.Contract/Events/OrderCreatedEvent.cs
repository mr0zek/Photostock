using DDD.Base.Domain;
using Photostock.Sales.Infrastructure;

namespace PhotoStock.Sales.Contract.Events
{
  public class OrderCreatedEvent : ISystemEvent
  {
      public AggregateId OrderId { get; private set; }

    public OrderCreatedEvent(AggregateId orderId)
    {
      OrderId = orderId;
    }
  }
}