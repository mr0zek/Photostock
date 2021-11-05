using System.Collections.Generic;
using DDD.Base.Domain;
using PhotoStock.SharedKernel;

namespace PhotoStock.Sales.Query.Events
{
  public class OrderConfirmedEventDto : EventDto
  {
    public AggregateId OrderId { get; private set; }
    public ClientData ClientData { get; private set; }
    public IEnumerable<OrderItemDto> Items { get; private set; }

    public OrderConfirmedEventDto(AggregateId orderId, ClientData clientData, IEnumerable<OrderItemDto> items, int version) : base(version)
    {
      OrderId = orderId;
      ClientData = clientData;
      Items = items;
    }
  }
}