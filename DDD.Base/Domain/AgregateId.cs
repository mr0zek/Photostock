using System;
using System.Collections.Generic;

namespace DDD.Base.Domain
{
  public class AggregateId : ValueObject
  {
    private string _innerId;

    public AggregateId(string value)
    {
      if (value == null)
      {
        throw new ArgumentNullException("value");
      }
      _innerId = value;
    }

    protected AggregateId()
    {
    }

    public static AggregateId Generate()
    {
      return new AggregateId(Guid.NewGuid().ToString());
    }

    public static implicit operator AggregateId(string value)
    {
      return new AggregateId(value);
    }

    public static implicit operator string(AggregateId aggregateId)
    {
      if (aggregateId != null)
      {
        return aggregateId._innerId;
      }
      return null;
    }
  }
}