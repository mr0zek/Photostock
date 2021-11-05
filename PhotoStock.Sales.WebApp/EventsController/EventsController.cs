using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PhotoStock.Sales.Query.Events;

namespace PhotoStock.Sales.WebApp.EventsController
{
  [Route("api/[controller]")]
  [ApiController]
  public class EventsController : Controller
  {
    private readonly IEventRepository _eventRepository;

    public EventsController(IEventRepository eventRepository)
    {
      _eventRepository = eventRepository;
    }

    [HttpGet()]
    public IActionResult Get([FromQuery]int? lastEventId, [FromQuery]int? count)
    {
      if (count == null)
      {
        count = 100;
      }
      return Json(_eventRepository.GetFrom(lastEventId, count.Value).ToArray(), new JsonSerializerSettings() { TypeNameHandling = TypeNameHandling.Objects });
    }
  }
}
