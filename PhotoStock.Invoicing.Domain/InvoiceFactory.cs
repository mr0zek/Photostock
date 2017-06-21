using DDD.Base.Domain;
using PhotoStock.Invoicing.Contract.Events;
using PhotoStock.SharedKernel;
using System;

namespace PhotoStock.Invoicing.Domain
{
  public class InvoiceFactory : IInvoiceFactory
  {
    private IInvoiceNumberGenerator _numberGenerator;
    private IDomainEventPublisher _eventPublisher;
    private IDependencyInjector _dependencyInjector;

    public InvoiceFactory(IDomainEventPublisher eventPublisher, IInvoiceNumberGenerator numberGenerator, IDependencyInjector dependencyInjector)
    {
      _eventPublisher = eventPublisher;
      _numberGenerator = numberGenerator;
      _dependencyInjector = dependencyInjector;
    }

    public Invoice Create(AggregateId orderId, ClientData clientData)
    {
      AggregateId number = _numberGenerator.GenerateNextInvoiceNumber();
      _eventPublisher.Publish(new OrderInvoicedEvent(orderId, number));

      Invoice invoice = new Invoice(number, clientData);
      _dependencyInjector.InjectDependencies(invoice);

      return invoice;
    }
  }
}