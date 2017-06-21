using DDD.Base.Domain;

namespace PhotoStock.Shipping.Domain
{
  public class ShipmentFactory : IShipmentFactory
  {
    private IDependencyInjector _dependencyInjector;

    public ShipmentFactory(IDependencyInjector dependencyInjector)
    {
      _dependencyInjector = dependencyInjector;
    }

    public Shipment CreateShipment(AggregateId orderId)
    {
      Shipment shipment = new Shipment(orderId);

      _dependencyInjector.InjectDependencies(shipment);

      return shipment;
    }
  }
}