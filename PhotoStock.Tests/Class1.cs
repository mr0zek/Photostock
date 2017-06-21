using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStock.Tests
{
  public class OrderingService
  {
    public void NewOrder(ClientId clientId)
    {
      Order o = _orderFactory.Create(clientId);

      _historyService.Add
      OrderHistory
    }
  }
}