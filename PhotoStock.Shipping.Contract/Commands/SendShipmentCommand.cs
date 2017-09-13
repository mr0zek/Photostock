using Bus;
using DDD.Base.Domain;

namespace PhotoStock.Shipping.Contract.Commands
{
  public class SendShipmentCommand : ICommand
  {
    public AggregateId OrderId { get; set; }

    public SendShipmentCommand(AggregateId orderId)
    {
      OrderId = orderId;
    }
  }
}