using System;

namespace DDD.Base.Domain.Exceptions
{
  public class IllegalStateException : Exception
  {
    public IllegalStateException(string message) : base(message)
    {
    }

    public IllegalStateException()
    {
    }
  }
}