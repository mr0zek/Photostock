namespace Photostock.Sales.Infrastructure
{
  public interface ISystemEventPublisher
  {
    void Publish<T>(T @event) where T : Bus.IEvent;
  }
}