using DDD.Base.Domain;
using DDD.Base.SharedKernel;
using PhotoStock.SharedKernel;

namespace PhotoStock.Sales.Domain.Client
{
  public class Client : AggregateRoot
  {
    private string _name;

    public Client(string name)
    {
      _name = name;
    }

    public ClientData GenerateSnapshot()
    {
      return new ClientData(AggregateId, _name);
    }

    public bool CanAfford(Money amount)
    {
      return true;//TODO explore domain rules ex: credit limit
    }

    public void Charge(Money amount)
    {
      if (!CanAfford(amount))
      {
        DomainError("Can not afford: " + amount);
      }
      // TODO facade to the payment module
    }

    public bool CanMakeReservation()
    {
      return true; //TODO explore domain rules (ex: cleint's debts, stataus etc)
    }
  }
}