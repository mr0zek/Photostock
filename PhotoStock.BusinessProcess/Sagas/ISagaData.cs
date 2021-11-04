using Automatonymous;

namespace PhotoStock.BusinessProcess.Sagas
{
  public interface ISagaData
  {
    State CurrentState { get; set; }
  }
}