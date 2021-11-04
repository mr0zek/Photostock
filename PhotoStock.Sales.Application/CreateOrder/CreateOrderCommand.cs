using System;

namespace PhotoStock.Sales.Application.CreateOrder
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