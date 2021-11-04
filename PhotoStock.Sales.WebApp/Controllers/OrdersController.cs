using CQRS.Base.Command;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PhotoStock.Sales.Application.Services.OrderingService;
using PhotoStock.Sales.Contract.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoStock.Sales.WebApp.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class OrdersController : ControllerBase
  {
    private readonly ICommandHandler<CreateOrderCommand> _createOrderHandler;
    private readonly ICommandHandler<AddPictureCommand> _addPictureCommandHandler;

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] string id)
    {
      throw new Exception();
    }

    [HttpPost]
    public IActionResult Post()
    {
      Guid orderId = Guid.NewGuid();
      _createOrderHandler.Handle(new CreateOrderCommand(orderId));
      
      return Created($"/Orders/{orderId}", orderId);
    }

    [HttpPost("{orderId}/Pictures")]
    public IActionResult PostPicture([FromRoute] string orderId, [FromBody] AddPictureRequest addPictureRequest)
    {
      _addPictureCommandHandler.Handle(new AddPictureCommand(orderId, addPictureRequest.PictureId, addPictureRequest.Quantity));
      
      return Created($"/Orders/{orderId}/Pictures/{addPictureRequest.PictureId}", addPictureRequest.PictureId);
    }

    [HttpGet("{orderId}/Offer")]
    public IActionResult GetOffer([FromRoute] string orderId)
    {
      OfferResponse offerResponse = new OfferResponse(); 

      return Ok(offerResponse);
    }

    [HttpPost("{orderId}/Confirmation")]
    public IActionResult PostConfirmation([FromBody] ConfirmationRequest confirmationRequest)
    {
      return Created("{orderId}/Confirmation","");
    }
  }
}
