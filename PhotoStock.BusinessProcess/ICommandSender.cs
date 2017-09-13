using Bus;

namespace PhotoStock.BusinessProcess
{
  public interface ICommandSender
  {
    void Send (ICommand command);
  }
}