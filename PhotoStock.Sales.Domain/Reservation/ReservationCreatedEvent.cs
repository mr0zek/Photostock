using DDD.Base.Domain;

namespace PhotoStock.Sales.Domain.Reservation
{
  public class ReservationCreatedEvent : IDomainEvent
  {
    public AggregateId AggregateId { get; set; }
    public int Version { get; set; }

    public ReservationCreatedEvent(AggregateId aggregateId, int version)
    {
      AggregateId = aggregateId;
      Version = version;
    }
  }
}