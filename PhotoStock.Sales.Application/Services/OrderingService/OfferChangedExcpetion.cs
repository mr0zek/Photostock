using DDD.Base.Domain;
using PhotoStock.Sales.Domain.Offer;
using System;
using System.Runtime.Serialization;

namespace PhotoStock.Sales.Application.Services.OrderingService
{
  public class OfferChangedExcpetion : Exception
  {
    public AggregateId OrderId { get; }
    public Offer SeenOffer { get; }
    public Offer NewOffer { get; }

    public OfferChangedExcpetion(AggregateId orderId, Offer seenOffer, Offer newOffer)
    {
      OrderId = orderId;
      SeenOffer = seenOffer;
      NewOffer = newOffer;
    }
  }
}