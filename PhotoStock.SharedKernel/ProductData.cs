using DDD.Base.Domain;

namespace PhotoStock.SharedKernel
{
  public class ProductData : ValueObject
  {
    public ProductData(AggregateId productId, Money price, string name, ProductType productType)
    {
      ProductId = productId;
      Price = price;
      Name = name;
      ProductType = productType;
    }

    public ProductType Type { get; set; }
    public AggregateId ProductId { get; set; }
    public Money Price { get; set; }
    public string Name { get; set; }
    public ProductType ProductType { get; set; }
  }
}