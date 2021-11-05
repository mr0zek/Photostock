using DDD.Base.Domain;
using System.Collections;
using System.Collections.Generic;

namespace PhotoStock.Sales.Query.Events
{
  public interface IEventRepository
  {
    void Add(EventDto result);
    IEnumerable<EventDto> GetFrom(int? lastEventId, int count);
  }
}