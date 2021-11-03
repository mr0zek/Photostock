using DDD.Base.Domain;

namespace PhotoStock.Shipping.Contract.Events
{
  public class OrderShippedEvent : IDomainEvent
  {
    public AggregateId OrderId { get; private set; }
    public AggregateId ShipmentId { get; private set; }

    public OrderShippedEvent(AggregateId orderId, AggregateId shipmentId)
    {
      OrderId = orderId;
      ShipmentId = shipmentId;
    }
  }
}