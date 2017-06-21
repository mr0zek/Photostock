using Automatonymous;
using DDD.Base.Domain;
using DDD.Infrastructure.Sagas;

namespace PhotoStock.BusinessProcess
{
  public class OrderSagaData : ISagaData
  {
    public State CurrentState { get; set; }
    public AggregateId OrderId { get; set; }
    public AggregateId InvoiceNumber { get; set; }
    public AggregateId ShipementId { get; set; }
  }
}