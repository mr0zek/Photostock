using DDD.Base.Domain;

namespace PhotoStock.Sales.Application.Services.OrderingService
{
  public class CalculateOfferCommand
  {
    public AggregateId OrderId { get; internal set; }
  }
}