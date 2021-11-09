using DDD.Base.Domain;

namespace PhotoStock.Sales.Contract.Events
{
  public class OrderPaidEvent : Event
  {
    public AggregateId OrderId { get; private set; }
  }
}