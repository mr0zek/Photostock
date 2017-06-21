using Automatonymous;

namespace DDD.Infrastructure.Sagas
{
  public interface ISagaData
  {
    State CurrentState { get; set; }
  }
}