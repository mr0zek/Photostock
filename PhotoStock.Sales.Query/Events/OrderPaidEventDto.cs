using DDD.Base.Domain;

namespace PhotoStock.Sales.Query.Events
{
  public class OrderPaidEventDto : EventDto
  {
    public string OrderId { get; private set; }

    public OrderPaidEventDto(string orderId, int version) : base(version, "OrderPaidEvent")
    {
      OrderId = orderId;
    }
  }
}