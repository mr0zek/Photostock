
namespace PhotoStock.Invoicing.Application
{
  public interface IEventListener<in TEvent>
  {
    void Handle(TEvent eventData);
  }
}