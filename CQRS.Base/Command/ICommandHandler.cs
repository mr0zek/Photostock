
namespace CQRS.Base.Command
{
  public interface ICommandHandler<TCommand>
  {
    void Handle(TCommand command);
  }
}