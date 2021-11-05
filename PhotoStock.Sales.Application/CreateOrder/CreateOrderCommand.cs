using System;

namespace PhotoStock.Sales.Application.CreateOrder
{
  public class CreateOrderCommand
  {
    public CreateOrderCommand(string orderId)
    {
      OrderId = orderId;
    }

    public string OrderId { get; }
  }
}