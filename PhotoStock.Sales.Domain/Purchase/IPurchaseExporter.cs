using DDD.Base.Domain;
using PhotoStock.Sales.Domain.ProductsCatalog;
using PhotoStock.SharedKernel;

namespace PhotoStock.Sales.Domain.Purchase
{
  public interface IPurchaseExporter
  {
    void ExportIdAndVersion(AggregateId purchaseId, int version);

    void ExportItem(ProductData productData, Money totalCost);

    void ExportClientId(AggregateId clientId);
  }
}