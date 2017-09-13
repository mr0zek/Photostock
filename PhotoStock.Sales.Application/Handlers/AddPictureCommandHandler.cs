using Bus;
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
    private IClientRepository _clientRepository;
    private ISystemContext _systemContext;

    public AddPictureCommandHandler(IReservationRepository reservationRepository, IProductRepository productRepository, IClientRepository clientRepository, ISystemContext systemContext)
    {
      _reservationRepository = reservationRepository;
      _productRepository = productRepository;
      _clientRepository = clientRepository;
      _systemContext = systemContext;
    }

    public void Handle(AddPictureCommand command)
    {
      Reservation reservation = _reservationRepository.Load(command.OrderId);

      Product product = _productRepository.Load(command.PictureId);

      if (!product.CanBeSold())
      {
        throw new ProductException("Product cannot be sold", product.AggregateId);
      }

      reservation.Add(product);

      _reservationRepository.Save(reservation);
    }
  }
}