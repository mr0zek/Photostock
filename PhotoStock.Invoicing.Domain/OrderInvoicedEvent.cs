using DDD.Base.Domain;

namespace PhotoStock.Invoicing.Domain
{
  public class OrderInvoicedEvent : IDomainEvent
  {
    public AggregateId OrderId { get; private set; }
    public AggregateId InvoiceNumber { get; private set; }

    public OrderInvoicedEvent(AggregateId orderId, AggregateId invoiceNumber)
    {
      OrderId = orderId;
      InvoiceNumber = invoiceNumber;
    }
  }
}