using DDD.Base.Domain;
using PhotoStock.Sales.Domain.Offer;

namespace PhotoStock.Sales.Application.Services.OrderingService
{
  public interface IOrderingService
  {
    // 1.
    //AggregateId CreateOrder();

    // 2.
    //void AddPicture(AggregateId orderId, AggregateId productId);

    // 3.
    //Offer CalculateOffer(AggregateId orderId);

    // 4.
    //void Confirm(AggregateId orderId, Offer seenOffer);
  }
}