using System.Threading.Tasks;
using RestEase;

namespace PhotoStock.Sales.Tests
{
  public interface ISalesApi
  {
    [Post("api/orders")]
    Task<string> CreateOrder();

    [Post("api/orders/{orderId}/pictures")]
    Task AddPicture([Path] string orderId, [Body] object pictureData);

    [Post("api//{orderId}/offers")]
    Task<string> CreateOffer([Path] string orderId);

    [Get("api/orders/{orderId}/offers/{offerId}")]
    Task GetOffer([Path] string orderId, [Path] string offerId);

    [Post("api/orders/{orderId}/offers/{offerId}/confirmation")]
    Task ConfirmOffer([Path] string orderId, [Path]string offerId);
  }
}