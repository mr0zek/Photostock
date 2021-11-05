
namespace DDD.Base.Domain
{
  // Remove marker interface
  //[Domain@event]
  public interface IDomainEvent
  {
    public int Version { get; set; }
  }
}