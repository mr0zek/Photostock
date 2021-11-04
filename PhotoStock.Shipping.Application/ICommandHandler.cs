
namespace PhotoStock.Shipping.Application
{
  public interface ICommandHandler<TCommand>
  {
    void Handle(TCommand command);
  }
}