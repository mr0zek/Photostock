using DDD.Base.Domain;

namespace PhotoStock.Invoicing.Domain
{
  public class OrderInvoicedEvent : IDomainEvent
  {
    public AggregateId OrderId { get; }
    public AggregateId InvoiceNumber { get; }
    public int Version { get; set; }

    public OrderInvoicedEvent(AggregateId orderId, AggregateId invoiceNumber)
    {
      OrderId = orderId;
      InvoiceNumber = invoiceNumber;
    }
  }
}