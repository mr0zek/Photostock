using System.Collections.Generic;

namespace PhotoStock.Sales.Query.Reservation
{
  public interface IReservationFinder
  {
    ReservationDto Get(string id);
    IEnumerable<ReservationDto> GetAll();
  }
}