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

    public Client(AggregateId clientId, string name, bool isVip,Money cash, Money maxCreditLimit) : base(clientId)
    {
      _isVip = isVip;
      _creditLimit = _maxCreditLimit = maxCreditLimit;
      _name = name;
      _cash = cash;
    }

    public ClientData GenerateSnapshot()
    {
      return new ClientData(AggregateId, _name);
    }

    public bool CanAfford(Money amount)
    {
      if (_isVip)
      {
        if (_creditLimit > amount)
        {
          return true;
        }
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