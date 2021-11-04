using DDD.Base.SharedKernel.Specification;

namespace PhotoStock.Sales.Domain.Offer.Specification
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