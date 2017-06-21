namespace CQRS.Base.Events
{
  public interface IEventListener<in TEvent>
  {
    void Handle(TEvent eventData);
  }
}