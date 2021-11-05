using DDD.Base.Domain;
using PhotoStock.Sales.Query.Events;
using System.Collections;
using System.Collections.Generic;

namespace PhotoStock.Sales.Infrastructure.Events
{
  class InMemoryEventRepository : IEventRepository
  {
    private static List<EventDto> _events = new List<EventDto>();
    private IEventsConverter _eventsConverter;

    public void Add(EventDto @event)
    {
      _events.Add(@event);
    }

    public IEnumerable<EventDto> GetFrom(int? lastEventId, int count)
    {
      int index = 0;
      if (lastEventId.HasValue)
      {
        index = _events.FindIndex(f => f.Id == lastEventId.Value);
      }
      return _events.GetRange(index, count);
    }
  }
}