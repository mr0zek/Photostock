using DDD.Base.SharedKernel.Specification;
using PhotoStock.Sales.Domain.Offer;

namespace PhotoStock.Sales.Application.Services
{
  public interface IOfferSpecificationFactory
  {
    ISpecification<Offer> Create();
  }
}