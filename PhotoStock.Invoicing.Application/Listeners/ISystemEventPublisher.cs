using PhotoStock.Invoicing.Contract.Events;

namespace PhotoStock.Invoicing.Application.Listeners
{
  public interface ISystemEventPublisher
  {
    void Publish(object @event);
  }
}