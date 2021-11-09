using DDD.Base.Domain;
using PhotoStock.SharedKernel;

namespace PhotoStock.Sales.Domain.Purchase
{
  public class PurchaseCreatedEvent : IDomainEvent
  {
    public AggregateId PurchaseId { get; set; }
    public int Version { get; set; }
    public ClientData ClientData { get; set; }

    public PurchaseCreatedEvent(AggregateId purchaseId, int version, ClientData clientData)
    {
      PurchaseId = purchaseId;
      Version = version;
      ClientData = clientData;
    }
  }
}