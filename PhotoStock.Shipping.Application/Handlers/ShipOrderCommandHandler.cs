using PhotoStock.Shipping.Contract.Commands;
using PhotoStock.Shipping.Domain;

namespace PhotoStock.Shipping.Application.Handlers
{
  public class ShipOrderCommandHandler : ICommandHandler<SendShipmentCommand>
  {
    private IShipmentFactory _factory;
    private IShipmentRepository _repository;

    public ShipOrderCommandHandler(IShipmentFactory factory, IShipmentRepository repository)
    {
      _factory = factory;
      _repository = repository;
    }

    public void Handle(SendShipmentCommand command)
    {
      Shipment shipment = _factory.CreateShipment(command.OrderId);
      shipment.Ship();
      _repository.Save(shipment);
    }
  }
}