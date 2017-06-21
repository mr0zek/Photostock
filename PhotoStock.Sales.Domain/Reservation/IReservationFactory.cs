namespace PhotoStock.Sales.Domain.Reservation
{
  public interface IReservationFactory
  {
    Reservation Create(Client.Client client);
  }
}