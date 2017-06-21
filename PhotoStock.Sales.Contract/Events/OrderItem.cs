using PhotoStock.SharedKernel;

namespace PhotoStock.Sales.Contract.Events
{
  public class OrderItem
  {
    public ProductData ProductData { get; set; }
    public Money TotalCost { get; set; }
  }
}