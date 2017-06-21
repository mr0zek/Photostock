using PhotoStock.Sales.Domain.ProductsCatalog;
using PhotoStock.SharedKernel;

namespace PhotoStock.Sales.Domain.Offer.Discount
{
  public class PercentDiscountPolicyDecorator : IDiscountPolicy
  {
    private readonly IDiscountPolicy _discountPolicy;
    private readonly string _couse;
    private readonly decimal _percent;

    public PercentDiscountPolicyDecorator(IDiscountPolicy discountPolicy, string couse, decimal percent)
    {
      _discountPolicy = discountPolicy;
      _couse = couse;
      _percent = percent;
    }

    public Discount ApplyDiscount(Product product, Money regularCost, Money totalCost)
    {
      Discount discount = _discountPolicy.ApplyDiscount(product, regularCost, totalCost);
      if(discount != null)
      { 
        discount.Cause += _couse+"\n";
        Money actualPrice = regularCost - discount.Value;
        discount.Value += actualPrice - ((_percent / 100) * actualPrice);
      }
      return discount;
    }
  }
}