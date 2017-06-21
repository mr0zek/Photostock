namespace DDD.Base.SharedKernel.Specification
{
  public class NotSpecification<T> : CompositeSpecification<T>
  {
    private ISpecification<T> _wrapped;

    public NotSpecification(ISpecification<T> wrapped)
    {
      _wrapped = wrapped;
    }

    public override bool IsSatisfiedBy(T offer)
    {
      return !_wrapped.IsSatisfiedBy(offer);
    }
  }
}