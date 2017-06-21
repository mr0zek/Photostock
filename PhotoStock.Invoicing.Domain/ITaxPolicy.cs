using PhotoStock.Invoicing.Domain.TaxPolicy;
using PhotoStock.SharedKernel;

namespace PhotoStock.Invoicing.Domain
{
  public interface ITaxPolicy
  {
    Tax CalculateTax(ProductType productType, Money net);
  }
}