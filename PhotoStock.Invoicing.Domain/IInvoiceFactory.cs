using DDD.Base.Domain;
using PhotoStock.SharedKernel;

namespace PhotoStock.Invoicing.Domain
{
  public interface IInvoiceFactory
  {
    Invoice Create(AggregateId orderId, ClientData clientData);
  }
}