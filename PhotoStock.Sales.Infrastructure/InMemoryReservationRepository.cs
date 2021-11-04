using System;
using System.Collections.Generic;
using System.Linq;
using DDD.Base.Domain;
using PhotoStock.Sales.Domain.Reservation;
using PhotoStock.Sales.Query.Reservation;

namespace PhotoStock.Sales.Infrastructure
{
  class InMemoryReservationRepository : IReservationFinder, IReservationRepository
  {
    private static Dictionary<string, Reservation> _items = new Dictionary<string, Reservation>();

    public ReservationDto Get(string id)
    {
      var reservation = _items[id].GetSnapshot();
      return new ReservationDto(reservation.ClientId, (DateTime)reservation.CreateDate, (int)reservation.Status);

    }

    public IEnumerable<ReservationDto> GetAll()
    {
      return _items.Values.Select(reservation => new ReservationDto(
        reservation.GetSnapshot().ClientId,
        (DateTime) reservation.GetSnapshot().CreateDate,
        (int) reservation.GetSnapshot().Status));
    }

    public Reservation Get(AggregateId id)
    {
      return _items[id];
    }

    public void Delete(AggregateId id)
    {
      _items.Remove(id);
    }

    public void Save(Reservation entity)
    {
      _items[entity.AggregateId] = entity;
    }
  }
}