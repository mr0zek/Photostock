using CQRS.Base.Command;
using PhotoStock.Sales.Domain.Client;
using PhotoStock.Sales.Domain.Reservation;
using PhotoStock.System;

namespace PhotoStock.Sales.Application.Services.OrderingService
{
  internal class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand>
  {
    private readonly IReservationFactory _reservationFactory;
    private readonly IReservationRepository _reservationRepository;
    private readonly IClientRepository _clientRepository;
    private readonly ISystemContext _systemContext;

    public CreateOrderCommandHandler(ISystemContext systemContext, IReservationFactory reservationFactory, IReservationRepository reservationRepository, IClientRepository clientRepository)
    {
      _systemContext = systemContext;
      _reservationFactory = reservationFactory;
      _reservationRepository = reservationRepository;
      _clientRepository = clientRepository;
    }

    public void Handle(CreateOrderCommand command)
    {
      Reservation reservation = _reservationFactory.Create(LoadClient());
      _reservationRepository.Save(reservation);      
    }

    private Client LoadClient()
    {
      return _clientRepository.Get(_systemContext.SystemUser.ClientId);
    }
  }
}