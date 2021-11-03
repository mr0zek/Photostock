
namespace PhotoStock.Sales.Domain.Offer.Discount
{
  public interface IDiscountFactory
  {
    IDiscountPolicy Create(Client.Client client);
  }
}