using DDD.Base.Domain;

namespace PhotoStock.Sales.Domain.Reservation
{
  public class ReservationCreatedEvent : IDomainEvent
  {
    public AggregateId AggregateId { get; set; }

    public ReservationCreatedEvent(AggregateId aggregateId)
    {
      AggregateId = aggregateId;
    }
  }
}