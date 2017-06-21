using DDD.Base.Domain;

namespace PhotoStock.Shipping.Contract.Commands
{
  public class DeliverShipmentCommand
  {
      public AggregateId ShipmentId { get; private set; }

    public DeliverShipmentCommand(AggregateId shipmentId)
    {
      ShipmentId = shipmentId;
    }
  }
}