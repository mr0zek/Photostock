namespace PhotoStock.Sales.Tests
{
  public class CreateOfferCommand
  {
    public CreateOfferCommand(string offerId)
    {
      OfferId = offerId;
    }

    public string OfferId { get; }
  }
}