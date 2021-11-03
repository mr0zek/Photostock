using CQRS.Base.Command;
using PhotoStock.Sales.Contract.Command;
using PhotoStock.Sales.Domain.Client;
using PhotoStock.Sales.Domain.ProductsCatalog;
using PhotoStock.Sales.Domain.Reservation;
using PhotoStock.System;

namespace PhotoStock.Sales.Application.Handlers
{
  public class AddPictureCommandHandler : ICommandHandler<AddPictureCommand>
  {
    private IReservationRepository _reservationRepository;
    private IProductRepository _productRepository;

    public AddPictureCommandHandler(IReservationRepository reservationRepository, IProductRepository productRepository)
    {
      _reservationRepository = reservationRepository;
      _productRepository = productRepository;
    }

    public void Handle(AddPictureCommand command)
    {
      Reservation reservation = _reservationRepository.Get(command.OrderId);

      Product product = _productRepository.Get(command.PictureId);

      if (!product.CanBeSold())
      {
        throw new ProductException("Product cannot be sold", product.AggregateId);
      }

      reservation.Add(product);

      _reservationRepository.Save(reservation);
    }
  }
}