using DDD.Base.Domain;

namespace PhotoStock.Invoicing.Contract.Events
{
  public class OrderInvoicedEvent 
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