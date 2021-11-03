
namespace CQRS.Base.Command
{
  public interface ICommandSender
  {
    void Send<TCommand>(TCommand command);
  }
}