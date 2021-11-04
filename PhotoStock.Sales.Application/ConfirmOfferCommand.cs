using DDD.Base.Domain;
using PhotoStock.Sales.Domain.Offer;

namespace PhotoStock.Sales.Application.Services.OrderingService
{
  public class ConfirmOfferCommand
  {
    public AggregateId OrderId { get; internal set; }
    public Offer SeenOffer { get; internal set; }
  }
}