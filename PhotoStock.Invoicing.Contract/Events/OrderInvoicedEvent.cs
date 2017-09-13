using Bus;
using DDD.Base.Domain;
using Photostock.Sales.Infrastructure;

namespace PhotoStock.Invoicing.Contract.Events
{
  public class OrderInvoicedEvent : IEvent
  {
    public AggregateId OrderId { get; }
    public AggregateId InvoiceNumber { get; }

    public OrderInvoicedEvent(AggregateId orderId, AggregateId invoiceNumber)
    {
      OrderId = orderId;
      InvoiceNumber = invoiceNumber;
    }
  }
}