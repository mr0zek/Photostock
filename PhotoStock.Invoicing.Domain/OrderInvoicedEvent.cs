using Bus;
using DDD.Base.Domain;
using Photostock.Sales.Infrastructure;

namespace PhotoStock.Invoicing.Domain
{
  public class OrderInvoicedEvent : IEvent
  {
    public AggregateId OrderId { get; }
    public AggregateId InvoiceNumber { get; }

    public OrderInvoicedEvent(AggregateId orderId)
    {
      OrderId = orderId;
    }
  }
}