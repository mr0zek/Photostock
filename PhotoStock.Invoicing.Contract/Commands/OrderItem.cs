using PhotoStock.SharedKernel;

namespace PhotoStock.Invoicing.Contract.Commands
{
  public class OrderItem
  {
    public OrderItem(ProductData productData, int quantity, Money totalCost)
    {
      ProductData = productData;
      Quantity = quantity;
      TotalCost = totalCost;
    }

    public Money TotalCost { get; set; }
    public ProductData ProductData { get; set; }
    public int Quantity { get; set; }
  }
}