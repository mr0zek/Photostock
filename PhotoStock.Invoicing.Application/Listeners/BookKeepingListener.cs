using Bus;
using Photostock.Sales.Infrastructure;
using PhotoStock.Invoicing.Domain;
using PhotoStock.Sales.Contract.Events;
using PhotoStock.SharedKernel;

namespace PhotoStock.Sales.Application.Listeners
{
  public class BookKeepingListener : IEventListener<OrderConfirmedEvent>
  {
    private readonly IInvoiceRepository _invoiceRepository;
    private ITaxPolicy _taxPolicy;
    private IInvoiceFactory _invoiceFactory;
    private ISystemEventPublisher _eventPublisher;

    public BookKeepingListener(IInvoiceRepository invoiceRepository, IInvoiceFactory invoiceFactory, ITaxPolicy taxPolicy)
    {
      _invoiceRepository = invoiceRepository;
      _invoiceFactory = invoiceFactory;
      _taxPolicy = taxPolicy;
    }

    public void Handle(OrderConfirmedEvent @event)
    {
      Invoice invoice = _invoiceFactory.Create(@event.OrderId, @event.ClientData);

      foreach (OrderItem item in @event.Items)
      {
        Money net = item.TotalCost;
        Tax tax = _taxPolicy.CalculateTax(item.ProductData.Type, net);

        InvoiceLine invoiceLine = new InvoiceLine(item.ProductData, 1, net, tax);
        invoice.AddItem(invoiceLine);
      }

      _invoiceRepository.Save(invoice);

      _eventPublisher.Publish(new OrderInvoicedEvent(@event.OrderId));
    }
  }
}