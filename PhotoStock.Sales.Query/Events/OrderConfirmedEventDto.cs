using System.Collections.Generic;
using DDD.Base.Domain;
using PhotoStock.SharedKernel;

namespace PhotoStock.Sales.Query.Events
{
  public class OrderConfirmedEventDto : EventDto
  {
    public AggregateId OrderId { get; }
    public ClientData ClientData { get; }
    public List<OrderItemDto> Items { get; }

    public OrderConfirmedEventDto(AggregateId orderId, ClientData clientData, List<OrderItemDto> items, int version) : base(version,"OrderConfirmedEvent")
    {
      OrderId = orderId;
      ClientData = clientData;
      Items = items;
    }
  }
}