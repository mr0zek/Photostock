using DDD.Base.Domain;
using PhotoStock.SharedKernel;

namespace PhotoStock.Sales.Domain.Offer.Discount
{
  public class Discount : ValueObject
  {
    public string Cause { get; set; }
    public Money Value { get; set; }

    public Discount(string cause, Money value)
    {
      Cause = cause;
      Value = value;
    }
  }
}