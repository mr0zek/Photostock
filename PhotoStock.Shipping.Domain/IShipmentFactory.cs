using DDD.Base.Domain;

namespace PhotoStock.Shipping.Domain
{
  public interface IShipmentFactory
  {
    Shipment CreateShipment(AggregateId orderId);
  }
}