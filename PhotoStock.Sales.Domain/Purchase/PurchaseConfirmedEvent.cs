using DDD.Base.Domain;

namespace PhotoStock.Sales.Domain.Purchase
{
  public class PurchaseConfirmedEvent : IDomainEvent
  {
    public AggregateId PurchaseId { get; set; }

    public PurchaseConfirmedEvent(AggregateId purchaseId)
    {
      PurchaseId = purchaseId;
    }
  }
}