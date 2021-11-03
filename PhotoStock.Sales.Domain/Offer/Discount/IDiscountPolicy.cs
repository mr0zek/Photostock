using PhotoStock.Sales.Domain.ProductsCatalog;
using PhotoStock.SharedKernel;

namespace PhotoStock.Sales.Domain.Offer.Discount
{
  public interface IDiscountPolicy
  {
    Discount ApplyDiscount(ProductData product, Money regularCost, Money totalCost);
  }
}