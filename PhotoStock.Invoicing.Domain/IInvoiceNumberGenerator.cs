using DDD.Base.Domain;

namespace PhotoStock.Invoicing.Domain
{
  public interface IInvoiceNumberGenerator
  {
    AggregateId GenerateNextInvoiceNumber();
  }
}