
namespace PhotoStock.Shipping.Application.Listeners
{
  public interface IEventListener<in TEvent>
  {
    void Handle(TEvent eventData);
  }
}