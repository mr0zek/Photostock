namespace Bus
{
  public interface IEventListener<in TEvent> where TEvent:IEvent
  {
    void Handle(TEvent eventData);
  }
}