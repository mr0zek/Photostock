using DDD.Base.Domain;
using PhotoStock.Sales.Domain.Offer;
using NotImplementedException = System.NotImplementedException;

namespace PhotoStock.Sales.Application.ConfirmOffer
{
  public class ConfirmOfferCommand
  {
    public ConfirmOfferCommand(string orderId, string offerId)
    {
      OrderId = orderId;
      OfferId = offerId;
    }

    public AggregateId OrderId { get; internal set; }
    public string OfferId { get; }
  }
}