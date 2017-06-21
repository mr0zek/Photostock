using DDD.Base.Domain;
using DDD.Base.SharedKernel;
using PhotoStock.Sales.Domain.ProductsCatalog;
using PhotoStock.SharedKernel;

namespace PhotoStock.Sales.Domain.Purchase
{
  public class PurchaseItem : Entity
  {
      public ProductData ProductData { get; private set; }
      public Money TotalCost { get; private set; }

    private PurchaseItem()
    {
    }

    public PurchaseItem(ProductData productData, Money totalCost)
    {
      ProductData = productData;
      TotalCost = totalCost;
    }
  }
}