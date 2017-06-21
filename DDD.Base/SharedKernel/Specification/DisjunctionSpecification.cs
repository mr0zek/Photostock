using System.Linq;

namespace DDD.Base.SharedKernel.Specification
{
    public class DisjunctionSpecification<T> : CompositeSpecification<T>
    {
        private readonly ISpecification<T>[] _disjunction;

        public DisjunctionSpecification(ISpecification<T>[] disjunction)
        {
            _disjunction = disjunction;
        }

        public override bool IsSatisfiedBy(T offer)
        {
            return _disjunction.Any(spec => spec.IsSatisfiedBy(offer));
        }
    }
}