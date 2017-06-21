using DDD.Base.Domain;
using System;

namespace PhotoStock.Sales.Domain.Reservation
{
  internal class ReservationItem
  {
    internal AggregateId ProductId { get; set; }

    public ReservationItem(AggregateId productId)
    {
      ProductId = productId;
    }
  }
}