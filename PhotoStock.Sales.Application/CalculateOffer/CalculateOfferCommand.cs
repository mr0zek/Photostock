using DDD.Base.Domain;
using PhotoStock.Sales.Domain.Offer;
using NotImplementedException = System.NotImplementedException;

namespace PhotoStock.Sales.Application.CalculateOffer
{
  public class CalculateOfferCommand
  {
    public CalculateOfferCommand(string orderId, string offerId)
    {
      OrderId = orderId;
    }

    public AggregateId OrderId { get; internal set; }
    public Offer OfferId { get; set; }
  }
}