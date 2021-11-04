using System.Collections.Generic;
using DDD.Base.Domain;
using PhotoStock.Sales.Domain.Offer;
using PhotoStock.Sales.Domain.Offer.Discount;
using PhotoStock.SharedKernel;

namespace PhotoStock.Sales.Query.Offer
{
  public class OfferDto
  {
    public AggregateId ClientId { get; }
    public IEnumerable<OfferItemDto> AvailableItems { get; }
    public Money TotalCost { get; }

    public OfferDto(AggregateId clientId, IEnumerable<OfferItemDto> availableItems, Money totalCost)
    {
      ClientId = clientId;
      AvailableItems = availableItems;
      TotalCost = totalCost;
    }
  }
}