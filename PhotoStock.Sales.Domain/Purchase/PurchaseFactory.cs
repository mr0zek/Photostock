using DDD.Base.Domain;
using DDD.Base.SharedKernel;
using PhotoStock.Sales.Domain.Offer;
using PhotoStock.SharedKernel;
using System.Collections.Generic;
using System.Linq;

namespace PhotoStock.Sales.Domain.Purchase
{
  public class PurchaseFactory : IPurchaseFactory
  {
    private IDomainEventPublisher _domainEventsPublisher;

    public PurchaseFactory(IDomainEventPublisher domainEventsPublisher)
    {
      _domainEventsPublisher = domainEventsPublisher;
    }

    public Purchase Create(AggregateId orderId, Client.Client client, Offer.Offer offer)
    {
      if (!CanPurchse(client, offer.AvailableItems))
        throw new DomainOperationException(client.AggregateId, "client can not purchase");

      List<PurchaseItem> items = new List<PurchaseItem>(offer.AvailableItems.Count());
      Money purchaseTotlCost = Money.ZERO;

      foreach (OfferItem item in offer.AvailableItems)
      {
        PurchaseItem purchaseItem = new PurchaseItem(item.ProductData, item.TotalCost);
        items.Add(purchaseItem);
        purchaseTotlCost = purchaseTotlCost.Add(purchaseItem.TotalCost);
      }

      Purchase purchase = new Purchase(orderId, client.AggregateId,
        items, Date.Today(), false, purchaseTotlCost);

      _domainEventsPublisher.Publish(new PurchaseCreatedEvent(purchase.AggregateId, purchase.Version, client.GenerateSnapshot()));

      return purchase;
    }

    private bool CanPurchse(Client.Client client, IEnumerable<OfferItem> availabeItems)
    {
      return true; //TODO explore domain rules
    }
  }
}