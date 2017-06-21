using DDD.Base.Domain;
using DDD.Base.SharedKernel;
using PhotoStock.SharedKernel;
using System;

namespace PhotoStock.Sales.Domain.Reservation
{
  public class ReservationFactory : IReservationFactory
  {
    public Reservation Create(Client.Client client)
    {
      //TODO:
      throw new NotImplementedException();
    }
  }
}