using Automatonymous;
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

      Event(() => OrderShippedEvent);

      Initially(
        When(OrderCreatedEvent)
          .Then(ctx => ctx.Instance.OrderId = ctx.Data.OrderId)
          .TransitionTo(OrderCreated));

      During(OrderCreated,
        When(OrderConfirmedEvent)
          .Then(ctx =>
          {
            var cmd = new InvoiceOrderCommand(
              ctx.Instance.OrderId,
              ctx.Data.ClientData,
              ctx.Data.Items.Select(f =>
                new OrderItem(f.ProductData, 1, f.TotalCost)));
            _commandSender.Send(cmd);
          })
          .TransitionTo(OrderConfirmed));

      During(OrderConfirmed,
          When(OrderInvoicedEvent)
              .Then(ctx =>
              {
                ctx.Instance.InvoiceNumber = ctx.Data.InvoiceNumber;
                _commandSender.Send(new SendShipmentCommand(ctx.Instance.OrderId));
              })
              .TransitionTo(OrderInvoiced));

      During(OrderInvoiced,
        When(OrderShippedEvent)
          .Then(ctx => ctx.Instance.ShipementId = ctx.Data.ShipmentId)
          .TransitionTo(OrderShipped));
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