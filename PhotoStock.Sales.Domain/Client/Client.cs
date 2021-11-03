using DDD.Base.Domain;
using DDD.Base.SharedKernel;
using PhotoStock.SharedKernel;

namespace PhotoStock.Sales.Domain.Client
{
  public class Client : AggregateRoot
  {
    private string _name;
    private Money _creditLimit;
    private bool _isVip;
    private Money _cash;
    private readonly Money _maxCreditLimit;

    public Client(string name, bool isVip)
    {
      _isVip = isVip;
      _maxCreditLimit = 100;
      _name = name;
    }

    public ClientData GenerateSnapshot()
    {
      return new ClientData(AggregateId, _name);
    }

    public bool CanAfford(Money amount)
    {
      if (_isVip)
      {
        if (_creditLimit < _maxCreditLimit)
        {
          return true;
        }
        return false;
      }

      if (_cash < amount)
      {
        return false;
      }
      return true;
    }

    public void Charge(Money amount)
    {
      if (!CanAfford(amount))
      {
        DomainError("Can not afford: " + amount);
      }

      if (_cash > amount)
      {
        _cash -= amount;
        return;
      }
      if (_isVip)
      {
        _creditLimit -= amount;
      }
    }

    public bool CanMakeReservation()
    {
      return true; //TODO explore domain rules (ex: cleint's debts, stataus etc)
    }
  }
}