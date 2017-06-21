using DDD.Base.Domain;
using DDD.Base.SharedKernel;
using PhotoStock.SharedKernel;
using System;
using System.Collections.Generic;

namespace PhotoStock.Sales.Domain.Offer
{
  public class Offer : ValueObject
  {
    private List<OfferItem> _availableItems = new List<OfferItem>();

    public IEnumerable<OfferItem> AvailableItems
    {
      get { return _availableItems; }
    }

    private List<OfferItem> _unavailableItems = new List<OfferItem>();

    public IEnumerable<OfferItem> UnavailableItems
    {
      get { return _unavailableItems; }
    }

    public Money TotalCost { get; private set;}
    public AggregateId ClientId { get; private set; }
    public Address ShipingAddress { get; set; }

    public Offer(AggregateId clientId, List<OfferItem> availabeItems, List<OfferItem> unavailableItems)
    {
        TotalCost = Money.ZERO;
      ClientId = clientId;
      _availableItems = availabeItems;
      _unavailableItems = unavailableItems;

      foreach (OfferItem offerItem in availabeItems)
      {
        TotalCost = TotalCost + offerItem.TotalCost;
      }
    }

    public bool SameAs(Offer seenOffer, double delta)
    {
      //TODO:
      throw new NotImplementedException();
    }

    private OfferItem FindItem(AggregateId productId)
    {
      foreach (OfferItem item in _availableItems)
      {
        if (item.ProductData.ProductId.Equals(productId))
          return item;
      }
      return null;
    }
  }
}