
namespace DDD.Base.Sagas
{
  public interface ISagaManager
  {
    void ProcessMessage<T>(T message);
  }
}