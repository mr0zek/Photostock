
using DDD.Base.Domain;

namespace PhotoStock.Sales.Domain.Reservation
{
  public interface IReservationFactory
  {
    Reservation Create(AggregateId reservationId, Client.Client client);
  }
}