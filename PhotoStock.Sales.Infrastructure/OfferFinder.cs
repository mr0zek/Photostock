using System.Collections.Generic;
using System.Linq;
using PhotoStock.Sales.Domain.Offer;
using PhotoStock.Sales.Query.Offer;

namespace PhotoStock.Sales.Infrastructure
{
  class InMemoryOfferRepository : IOfferFinder, IOfferRepository
  {
    private Dictionary<string, Offer> _items = new Dictionary<string, Offer>();

    public OfferDto Get(string offerId)
    {
      var offer = _items[offerId];
      return new OfferDto(
        offer.ClientId, 
        offer.AvailableItems.Select(f=>new OfferItemDto(f.ProductData.ProductId,f.Discount.Value, f.TotalCost)), 
        offer.TotalCost);
    }

    public void Save(Offer commandOfferId, Offer offer)
    {
      
    }

    Offer IOfferRepository.Get(string offerId)
    {
      return _items[offerId];
    }
  }
}