namespace PhotoStock.Sales.Query.Offer
{
  public class OfferItemDto
  {
    public string ProductId { get; }
    public decimal Discount { get; }
    public decimal TotalCost { get; }

    public OfferItemDto(string productId, decimal discount, decimal totalCost)
    {
      ProductId = productId;
      Discount = discount;
      TotalCost = totalCost;
    }
  }
}