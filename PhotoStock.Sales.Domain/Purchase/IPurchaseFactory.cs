using DDD.Base.Domain;

namespace PhotoStock.Sales.Domain.Purchase
{
  public interface IPurchaseFactory
  {
    Purchase Create(AggregateId orderId, Client.Client client, Offer.Offer offer);
  }
}