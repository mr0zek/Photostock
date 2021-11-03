using DDD.Base.Domain;
using PhotoStock.Sales.Domain.Offer;

namespace PhotoStock.Sales.Application.Services.OrderingService
{
  public interface IOrderingService
  {
    // 1.
    // Post /Order/
    //AggregateId CreateOrder();

    // 2.
    // Post /Order/{id}/Picture
    //void AddPicture(AggregateId orderId, AggregateId productId);

    // 3.    
    // Get /Order/{orderId}/Offer/
    //Offer CalculateOffer(AggregateId orderId);

    // 4.
    // Post /Order/{orderId}/Confirmation/
    //void Confirm(AggregateId orderId, Offer seenOffer);

    //Get /Order/
    //Get /Order/{OrderId}
  }
}