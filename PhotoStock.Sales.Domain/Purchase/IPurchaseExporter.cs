using DDD.Base.Domain;
using PhotoStock.Sales.Domain.ProductsCatalog;
using PhotoStock.SharedKernel;

namespace PhotoStock.Sales.Domain.Purchase
{
  public interface IPurchaseExporter
  {
    void ExportId(AggregateId purchaseId);

    void ExportItem(ProductData productData, Money totalCost);

    void ExportClientId(AggregateId clientId);
  }
}