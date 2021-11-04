using System.Collections.Generic;

namespace PhotoStock.Sales.Infrastructure
{
  class InMemoryEventsRepository : IEventsRepository
  {
    private static List<object> _events = new List<object>();

    public void Add(object @event)
    {
      _events.Add(@event);
    }
  }
}