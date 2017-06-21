using DDD.Base.Domain;

namespace PhotoStock.Sales.Application.Services.PurchaseService
{
  internal interface IPaymentService
  {
    void ConfirmOrderPayment(AggregateId orderId);
  }
}