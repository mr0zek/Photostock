using System.Collections.Generic;
using DDD.Base.Domain;
using PhotoStock.SharedKernel;

namespace PhotoStock.Sales.Domain.Reservation
{
  public class ReservationData
  {
    public Reservation.ReservationStatus Status { get; }
    public AggregateId ClientId { get; }
    public Date CreateDate { get; }
    public IEnumerable<AggregateId> ProductsIds { get; }

    public ReservationData(Reservation.ReservationStatus status, AggregateId clientId, Date createDate, IEnumerable<AggregateId> productsIds)
    {
      Status = status;
      ClientId = clientId;
      CreateDate = createDate;
      ProductsIds = productsIds;
    }
  }
}