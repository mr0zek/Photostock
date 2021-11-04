using DDD.Base.SharedKernel.Specification;

namespace PhotoStock.Sales.Domain.Offer.Specification
{
  public interface IOfferSpecificationFactory
  {
    ISpecification<Offer> Create();
  }
}