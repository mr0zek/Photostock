using DDD.Base.Domain;
using DDD.Base.SharedKernel.Specification;
using PhotoStock.SharedKernel;
using System;

namespace PhotoStock.Sales.Domain.Offer.Specification
{
  public class DebtorSpecification : CompositeSpecification<Offer>
  {
    private readonly Money _maxDebt;

    public DebtorSpecification(Money maxDebt)
    {
      _maxDebt = maxDebt;
    }

    // No debt is allowed
    public DebtorSpecification()
        : this(Money.ZERO)
    {
    }

    public override bool IsSatisfiedBy(Offer offer)
    {
      //TODO:
      throw new NotImplementedException();
    }

    private Money LoadDebt(AggregateId clientId)
    {
      // TODO load debt using injected Repo/Service to this Spec
      return Money.ZERO;
    }
  }
}