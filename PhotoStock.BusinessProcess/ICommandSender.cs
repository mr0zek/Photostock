
namespace PhotoStock.BusinessProcess
{
  public interface ICommandSender
  {
    void Send<TCommand>(TCommand command);
  }
}