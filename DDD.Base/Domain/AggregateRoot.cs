using System;

namespace DDD.Base.Domain
{
  public abstract class AggregateRoot
  {
    public enum AggregateStatus
    {
      ACTIVE, ARCHIVE
    }

    public AggregateId AggregateId { get; private set; }

    public int Version { get; private set; }
    private AggregateStatus _aggregateStatus = AggregateStatus.ACTIVE;

    protected IDomainEventPublisher EventPublisher { get; private set; }

    protected AggregateRoot()
    {
      Version = 0;
    }

    public AggregateRoot(AggregateId aggregateId)
    {
      AggregateId = aggregateId;
    }

    public void MarkAsRemoved()
    {
      _aggregateStatus = AggregateStatus.ARCHIVE;
    }

    public bool IsRemoved()
    {
      return _aggregateStatus == AggregateStatus.ARCHIVE;
    }

    protected void DomainError(string message)
    {
      throw new DomainOperationException(AggregateId, message);
    }
  }
}