using System;

namespace DDD.Base.Domain
{
  public class DomainOperationException : Exception
  {
    public AggregateId AggregateId { get; set; }

    public DomainOperationException(AggregateId aggregateId, string message) : base(message)
    {
      AggregateId = aggregateId;
    }
  }
}