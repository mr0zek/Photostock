using DDD.Base.Domain;
using PhotoStock.SharedKernel;
using System.Collections.Generic;

namespace PhotoStock.Sales.Domain.Purchase
{
  public class Purchase : AggregateRoot
  {
    private readonly IList<PurchaseItem> _items;
    public bool IsPaid { get; private set; }
    public AggregateId ClientId { get; private set; }
    private Date _purchaseDate;
    private Money _totalCost;

    protected Purchase()
    {
    }

    public Purchase(AggregateId purchaseId, AggregateId clientId, IList<PurchaseItem> items, Date purchaseDate,
      bool isPaid, Money totalCost) : base(purchaseId)
    {
      _items = items;
      _purchaseDate = purchaseDate;
      ClientId = clientId;
      IsPaid = isPaid;
      _totalCost = totalCost;
    }

    public void Confirm()
    {
      IsPaid = true;
      EventPublisher.Publish(new PurchaseConfirmedEvent(AggregateId, Version));
    }

    public void Export(IPurchaseExporter builder)
    {
      builder.ExportIdAndVersion(AggregateId, Version);
      builder.ExportClientId(ClientId);
      foreach (PurchaseItem purchaseItem in _items)
      {
        builder.ExportItem(purchaseItem.ProductData, purchaseItem.TotalCost);
      }
    }
  }
}