using DDD.Base.Domain;

namespace PhotoStock.Sales.Contract.Events
{
  public class OrderCreatedEvent 
  {
    public AggregateId OrderId { get; private set; }

    public OrderCreatedEvent(AggregateId orderId)
    {
      OrderId = orderId;
    }
  }
}