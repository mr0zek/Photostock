using DDD.Base.SharedKernel.Specification;
using PhotoStock.Sales.Domain.Offer;
using PhotoStock.Sales.Domain.Offer.Specification;

namespace PhotoStock.Sales.Application.Services
{
  internal class OfferSpecificationFactory : IOfferSpecificationFactory
  {
    public ISpecification<Offer> Create()
    {
      ISpecification<Offer> specification
        = new DebtorSpecification(); // not debts or max 1000 => debtors can

      return specification;
    }
  }
}