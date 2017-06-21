namespace DDD.Base.SharedKernel.Specification
{
  public class OrSpecification<T> : CompositeSpecification<T>
  {
    private ISpecification<T> _a;
    private ISpecification<T> _b;

    public OrSpecification(ISpecification<T> a, ISpecification<T> b)
    {
      _a = a;
      _b = b;
    }

    public override bool IsSatisfiedBy(T offer)
    {
      return _a.IsSatisfiedBy(offer) || _b.IsSatisfiedBy(offer);
    }
  }
}