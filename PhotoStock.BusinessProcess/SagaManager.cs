using CQRS.Base.Command;
using DDD.Infrastructure.Sagas;
using PhotoStock.Invoicing.Contract.Events;
using PhotoStock.Sales.Contract.Events;
using PhotoStock.Shipping.Contract.Events;

namespace PhotoStock.BusinessProcess
{
  public class OrderSagaManager : SagaManager<OrderSaga, OrderSagaData>
  {
    public OrderSagaManager(ISagaRepository<OrderSagaData> sagaRepository, ICommandSender commandSender)
      : base(new OrderSaga(commandSender), sagaRepository)
    {
      CorrelateEvent<OrderConfirmedEvent>(f => f.OrderId);
      CorrelateEvent<OrderShippedEvent>(f => f.OrderId);
      CorrelateEvent<OrderInvoicedEvent>(f => f.OrderId);
      CorrelateEvent<OrderCreatedEvent>(f => f.OrderId);
    }
  }
}