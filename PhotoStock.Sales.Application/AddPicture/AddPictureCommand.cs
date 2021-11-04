using DDD.Base.Domain;

namespace PhotoStock.Sales.Application.AddPicture
{
  public class AddPictureCommand
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