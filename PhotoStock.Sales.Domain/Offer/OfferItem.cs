using DDD.Base.Domain;
using DDD.Base.SharedKernel;
using PhotoStock.Sales.Domain.ProductsCatalog;
using PhotoStock.SharedKernel;

namespace PhotoStock.Sales.Domain.Offer
{
  public class OfferItem : ValueObject
  {
      public ProductData ProductData { get; private set; }
      public Discount.Discount Discount { get; private set; }
      public Money TotalCost { get; private set; }

    public OfferItem(ProductData productData) : this(productData, null)
    {
    }

    public OfferItem(ProductData productData, Discount.Discount discount)
    {
      ProductData = productData;
      Discount = discount;

      Money discountValue = Money.ZERO;
      if (discount != null)
      {
        discountValue = discountValue - discount.Value;
      }

      TotalCost = productData.Price - discountValue;
    }

    public bool SameAs(OfferItem item, double delta)
    {
      if (!ProductData.Equals(item.ProductData))
      {
        return false;
      }

      Money max, min;
      if (TotalCost > item.TotalCost)
      {
        max = TotalCost;
        min = item.TotalCost;
      }
      else
      {
        max = item.TotalCost;
        min = TotalCost;
      }

      Money difference = max - min;
      Money acceptableDelta = max * (delta / 100);

      return acceptableDelta > difference;
    }
  }
}