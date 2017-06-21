using DDD.Base.Domain;

namespace PhotoStock.System
{
  internal class SystemContext : ISystemContext
  {
    public SystemUser SystemUser
    {
      get
      {
        return new SystemUser(new AggregateId("1")); //TODO introduce security integration
      }
    }
  }
}