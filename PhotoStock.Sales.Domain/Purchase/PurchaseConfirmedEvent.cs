using DDD.Base.Domain;

namespace PhotoStock.Sales.Domain.Purchase
{
  public class PurchaseConfirmedEvent : IDomainEvent
  {
    public AggregateId PurchaseId { get; }

    public int Version { get; set; }

    public PurchaseConfirmedEvent(AggregateId purchaseId, int version)
    {
      PurchaseId = purchaseId;
      Version = version;
    }
  }
}