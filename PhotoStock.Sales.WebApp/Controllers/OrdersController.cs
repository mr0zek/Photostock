using Microsoft.AspNetCore.Mvc;
using System;
using PhotoStock.Sales.Application;
using PhotoStock.Sales.Application.AddPicture;
using PhotoStock.Sales.Application.CalculateOffer;
using PhotoStock.Sales.Application.ConfirmOffer;
using PhotoStock.Sales.Application.CreateOrder;
using PhotoStock.Sales.Domain.Offer;
using PhotoStock.Sales.Domain.Reservation;
using PhotoStock.Sales.Query;
using PhotoStock.Sales.Query.Offer;
using PhotoStock.Sales.Query.Reservation;

namespace PhotoStock.Sales.WebApp.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class OrdersController : ControllerBase
  {
    private readonly ICommandHandler<CreateOrderCommand> _createOrderHandler;
    private readonly ICommandHandler<AddPictureCommand> _addPictureCommandHandler;
    private readonly IReservationFinder _ordersFinder;
    private readonly ICommandHandler<CalculateOfferCommand> _calculateOffer;
    private readonly ICommandHandler<ConfirmOfferCommand> _confirmOffer;
    private readonly IOfferFinder _offerFinder;

    public OrdersController(ICommandHandler<CreateOrderCommand> createOrderHandler, ICommandHandler<AddPictureCommand> addPictureCommandHandler, IReservationFinder ordersFinder, ICommandHandler<CalculateOfferCommand> calculateOffer, ICommandHandler<ConfirmOfferCommand> confirmOffer, IOfferFinder offerFinder)
    {
      _createOrderHandler = createOrderHandler;
      _addPictureCommandHandler = addPictureCommandHandler;
      _ordersFinder = ordersFinder;
      _calculateOffer = calculateOffer;
      _confirmOffer = confirmOffer;
      _offerFinder = offerFinder;
    }

    [HttpGet()]
    public IActionResult Get()
    {
      return Ok(_ordersFinder.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult Get([FromRoute] string id)
    {
      return Ok(_ordersFinder.Get(id));
    }

    [HttpPost]
    public IActionResult CreateOrder()
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

    [HttpPost("{orderId}/Offers")]
    public IActionResult CreateOffer([FromRoute] string orderId)
    {
      string offerId = Guid.NewGuid().ToString();
      _calculateOffer.Handle(new CalculateOfferCommand(orderId, offerId));
      
      return Created($"/{orderId}/Offers/{offerId}", offerId);
    }

    [HttpPost("{orderId}/Offers/{offerId}")]
    public IActionResult GetOffer([FromRoute] string offerId)
    {
      return Ok(_offerFinder.Get(offerId));
    }

    [HttpPost("{orderId}/Offers/{offerId}/Confirmation")]
    public IActionResult PostConfirmation([FromRoute] string orderId, [FromBody] string offerId)
    {
      _confirmOffer.Handle(new ConfirmOfferCommand(orderId, offerId));
      return Created($"/{orderId}/Offers/{offerId}/Confirmation", "");
    }
  }
}
