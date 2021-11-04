
namespace PhotoStock.Invoicing.Application
{
  public interface ICommandHandler<TCommand>
  {
    void Handle(TCommand command);
  }
}