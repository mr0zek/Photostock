
namespace PhotoStock.Sales.Query.Offer
{
  public interface IOfferFinder
  {
    OfferDto Get(string offerId);
  }
}