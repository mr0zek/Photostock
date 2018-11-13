using System;

namespace DDD.Base.Domain
{
  public abstract class AggregateRoot
  {
    protected bool Equals(AggregateRoot other)
    {
      return Equals(AggregateId, other.AggregateId);
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != this.GetType()) return false;
      return Equals((AggregateRoot) obj);
    }

    public override int GetHashCode()
    {
      return (AggregateId != null ? AggregateId.GetHashCode() : 0);
    }

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