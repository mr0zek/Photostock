using DDD.Base.Domain;
using PhotoStock.Sales.Query.Events;
using System.Collections;
using System.Collections.Generic;

namespace PhotoStock.Sales.Infrastructure.Events
{
  class InMemoryEventRepository : IEventRepository
  {
    private static List<EventDto> _events = new List<EventDto>();
<<<<<<< HEAD
    private IEventsConverter _eventsConverter;

    public void Add(EventDto @event)
    {
=======

    public void Add(EventDto @event)
    {
      @event.Id = _events.Count+1;
>>>>>>> 93a0f79 (stage 5)
      _events.Add(@event);
    }

    public IEnumerable<EventDto> GetFrom(int? lastEventId, int count)
    {
      int index = 0;
      if (lastEventId.HasValue)
      {
<<<<<<< HEAD
        index = _events.FindIndex(f => f.Id == lastEventId.Value);
      }
      return _events.GetRange(index, count);
=======
        if (lastEventId.Value > _events.Count)
        {
          return new List<EventDto>();
        }
        index = lastEventId.Value;
      }

      int c = count;
      if (c > _events.Count - index)
      {
        c = _events.Count - index;
        if (c <= 0)
        {
          return new List<EventDto>();
        }
      }
      return _events.GetRange(index, c);
>>>>>>> 93a0f79 (stage 5)
    }
  }
}