using System.Threading.Tasks;
using RestEase;

namespace PhotoStock.Sales.Tests
{
  public interface ISalesApi
  {
    [Post("orders")]
    Task<string> CreateOrder();

    [Post("orders/{orderId}/pictures")]
    Task AddPicture([Path] string orderId, [Path] string pictureId);

    [Post("orders/{orderId}/offers")]
    Task<string> CreateOffer([Path] string orderId);

    [Get("orders/{orderId}/offers/{offerId}")]
    Task GetOffer([Path] string offerId);

    [Post("orders/{orderId}/offers/{offerId}/confirmation")]
    Task ConfirmOffer([Path]string offerId);
  }
}