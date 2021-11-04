namespace PhotoStock.Sales.Application.Services.OrderingService
{
  public interface IQueryHandler<out TReturnValue, in TCommand>
  {
    TReturnValue Handle(TCommand command);
  }
}