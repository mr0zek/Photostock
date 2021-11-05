using System;

namespace Bus
{
  public interface IBus
  {
    void Publish(object @event)
  }
}
