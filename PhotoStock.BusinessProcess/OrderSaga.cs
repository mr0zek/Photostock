using Automatonymous;
using CQRS.Base.Command;
using PhotoStock.Invoicing.Contract.Commands;
using PhotoStock.Invoicing.Contract.Events;
using PhotoStock.Sales.Contract.Events;
using PhotoStock.Shipping.Contract.Commands;
using PhotoStock.Shipping.Contract.Events;
using System.Linq;
using OrderItem = PhotoStock.Invoicing.Contract.Commands.OrderItem;

namespace PhotoStock.BusinessProcess
{
  public class OrderSaga : AutomatonymousStateMachine<OrderSagaData>
  {
    private ICommandSender _commandSender;

    public OrderSaga(ICommandSender commandSender)
    {
      _commandSender = commandSender;

      Event(() => OrderCreatedEvent);
      Event(() => OrderConfirmedEvent);
      Event(() => OrderShippedEvent);
      Event(() => OrderInvoicedEvent);
    }

    public State OrderCreated { get; set; }
    public State OrderShipped { get; set; }
    public State OrderConfirmed { get; set; }
    public State OrderInvoiced { get; set; }

    public Event<OrderCreatedEvent> OrderCreatedEvent { get; set; }
    public Event<OrderShippedEvent> OrderShippedEvent { get; set; }
    public Event<OrderConfirmedEvent> OrderConfirmedEvent { get; set; }
    public Event<OrderInvoicedEvent> OrderInvoicedEvent { get; set; }
  }
}