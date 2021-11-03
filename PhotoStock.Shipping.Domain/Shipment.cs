using DDD.Base.Domain;
using DDD.Base.Domain.Exceptions;
using PhotoStock.Shipping.Contract.Events;

namespace PhotoStock.Shipping.Domain
{
  public class Shipment : AggregateRoot
  {
    public AggregateId OrderId { get; private set; }

    public ShippingStatus ShipmentStatus { get; private set; }

    private Shipment()
    {
    }

    public Shipment(AggregateId orderId)
    {
      OrderId = orderId;
      ShipmentStatus = ShippingStatus.WAITING;
    }

    /**
     * Shipment has been sent to the customer.
     */

    public void Ship()
    {
      if (ShipmentStatus != ShippingStatus.WAITING)
      {
        throw new IllegalStateException("Cannot ship in status " + ShipmentStatus);
      }
      ShipmentStatus = ShippingStatus.SENT;
      EventPublisher.Publish(new OrderShippedEvent(OrderId, AggregateId));
    }
  }
}