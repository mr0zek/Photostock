using DDD.Base.Domain;

namespace PhotoStock.Shipping.Contract.Commands
{
  public class SendShipmentCommand
  {
    public AggregateId OrderId { get; set; }

    public SendShipmentCommand(AggregateId orderId)
    {
      OrderId = orderId;
    }
  }
}