using PhotoStock.Sales.Application.Listeners;
using PhotoStock.Sales.Contract.Events;

namespace PhotoStock.Invoicing.Application
{
  class Bootstrap
  {
    public void Configure()
    {
      Bus.Bus.RegisterEventListener<OrderConfirmedEvent, BookKeepingListener>();
    }
  }
}
