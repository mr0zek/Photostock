
namespace PhotoStock.Sales.Application
{
  public interface ICommandHandler<TCommand>
  {
    void Handle(TCommand command);
  }
}