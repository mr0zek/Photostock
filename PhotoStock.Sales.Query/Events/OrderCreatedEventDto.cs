using DDD.Base.Domain;

namespace PhotoStock.Sales.Query.Events
{
  public class OrderCreatedEventDto : EventDto
  {
    public AggregateId OrderId { get; private set; }

    public OrderCreatedEventDto(AggregateId orderId, int version) :base(version)
    {
      OrderId = orderId;
    }
  }
}