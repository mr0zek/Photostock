using RestEase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PhotoStock.Sales.Tests
{
  public interface IEventsApi
  {
    [Get("api/events")]
    Task<Event[]> GetEvents([Query] int? lastEventId, [Query] int? count);
  }
}