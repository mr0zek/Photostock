using CQRS.Base.Command;
using PhotoStock.Invoicing.Contract.Commands;
using PhotoStock.Invoicing.Domain;
using PhotoStock.SharedKernel;
using OrderItem = PhotoStock.Invoicing.Contract.Commands.OrderItem;

namespace PhotoStock.Sales.Application.Listeners
{
  public class InvoiceOrderHandler : ICommandHandler<InvoiceOrderCommand>
  {
    private readonly IInvoiceRepository _invoiceRepository;
    private ITaxPolicy _taxPolicy;
    private IInvoiceFactory _invoiceFactory;

    public InvoiceOrderHandler(IInvoiceRepository invoiceRepository, IInvoiceFactory invoiceFactory, ITaxPolicy taxPolicy)
    {
      _invoiceRepository = invoiceRepository;
      _invoiceFactory = invoiceFactory;
      _taxPolicy = taxPolicy;
    }

    public void Handle(InvoiceOrderCommand @event)
    {
      Invoice invoice = _invoiceFactory.Create(@event.OrderId, @event.ClientData);

      foreach (OrderItem item in @event.Items)
      {
        Money net = item.TotalCost;
        Tax tax = _taxPolicy.CalculateTax(item.ProductData.Type, net);

        InvoiceLine invoiceLine = new InvoiceLine(item.ProductData, item.Quantity, net, tax);
        invoice.AddItem(invoiceLine);
      }

      _invoiceRepository.Save(invoice);
    }
  }
}