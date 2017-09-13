using Bus;
using DDD.Base.Domain;

namespace PhotoStock.Sales.Contract.Command
{
  public class AddPictureCommand : ICommand
  {
    public AggregateId OrderId { get; }
    public AggregateId PictureId { get; }
    public int Quantity { get; }

    public AddPictureCommand(AggregateId orderId, AggregateId pictureId, int quantity)
    {
      OrderId = orderId;
      PictureId = pictureId;
      Quantity = quantity;
    }
  }
}