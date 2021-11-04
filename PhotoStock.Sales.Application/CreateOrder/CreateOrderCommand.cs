using System;

namespace PhotoStock.Sales.Application.Services.OrderingService
{
  public class CreateOrderCommand
  {
    public CreateOrderCommand(Guid orderId)
    {
      OrderId = orderId;
    }

    public Guid OrderId { get; }
  }
}