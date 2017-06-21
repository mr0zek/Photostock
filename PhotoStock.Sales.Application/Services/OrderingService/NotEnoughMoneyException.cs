using PhotoStock.SharedKernel;
using System;
using System.Runtime.Serialization;

namespace PhotoStock.Sales.Application.Services.OrderingService
{
  public class NotEnoughMoneyException : Exception
  {
    public Money RequiredAmount { get; }

    public NotEnoughMoneyException(Money requiredAmount)
    {
      RequiredAmount = requiredAmount;
    }
  }
}