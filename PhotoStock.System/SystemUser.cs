using DDD.Base.Domain;

namespace PhotoStock.System
{
  public class SystemUser
  {
    public AggregateId ClientId { get; private set; }

    internal SystemUser(AggregateId clientId)
    {
      ClientId = clientId;
    }

    public bool IsLoogedIn()
    {
      return ClientId != null;
    }
  }
}