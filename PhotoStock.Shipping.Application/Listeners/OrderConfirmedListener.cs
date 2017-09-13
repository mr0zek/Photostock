using Bus;
using PhotoStock.Invoicing.Contract.Events;
using PhotoStock.Sales.Contract.Events;
using PhotoStock.Shipping.Domain;

namespace PhotoStock.Shipping.Application.Listeners
{
  public class OrderInvoicedListener : IEventListener<OrderInvoicedEvent>
  {
    private IShipmentFactory _factory;
    private IShipmentRepository _repository;

    public OrderInvoicedListener(IShipmentFactory factory, IShipmentRepository repository)
    {
      _factory = factory;
      _repository = repository;
    }

    public void Handle(OrderInvoicedEvent @event)
    {
      Shipment shipment = _factory.CreateShipment(@event.OrderId);
      shipment.Ship();
      _repository.Save(shipment);
    }
  }
}