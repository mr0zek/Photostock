using DDD.Base.Domain;
using PhotoStock.Sales.Domain.Client;
using PhotoStock.Sales.Domain.Purchase;

namespace PhotoStock.Sales.Application.Services.PurchaseService
{
  internal class PaymentService : IPaymentService
  {
    private readonly IPurchaseRepository _purchaseRepository;

    public PaymentService(IPurchaseRepository purchaseRepository)
    {
      _purchaseRepository = purchaseRepository;
    }

    public void ConfirmOrderPayment(AggregateId orderId)
    {
      Purchase purchase = _purchaseRepository.Load(orderId);
      purchase.Confirm();
      _purchaseRepository.Save(purchase);
    }
  }
}