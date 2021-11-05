namespace PhotoStock.Sales.Domain.Offer
{
  public interface IOfferRepository
  {
    Offer Get(string offerId);
    void Save(string offerId, Offer offer);
  }
}