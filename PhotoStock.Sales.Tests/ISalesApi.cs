using System.Threading.Tasks;
using RestEase;

namespace PhotoStock.Sales.Tests
{
  public interface ISalesApi
  {
    [Post("api/orders")]
    Task<string> CreateOrder([Body]CreateOrderCommand orderId = null);

    [Post("api/orders/{orderId}/pictures")]
    Task AddPicture([Path] string orderId, [Body] object pictureData);


    [Post("api/orders/{orderId}/offers")]
    Task<string> CreateOffer([Path] string orderId,[Body]CreateOfferCommand offerId = null);

    [Get("api/orders/{orderId}/offers/{offerId}")]
    Task GetOffer([Path] string orderId, [Path] string offerId);

    [Post("api/orders/{orderId}/offers/{offerId}/confirmation")]
    Task ConfirmOffer([Path] string orderId, [Path]string offerId);
  }

  public class CreateOrderCommand
  {
    public CreateOrderCommand(string orderId)
    {
      OrderId = orderId;
    }

    public string OrderId { get; }
  }
}