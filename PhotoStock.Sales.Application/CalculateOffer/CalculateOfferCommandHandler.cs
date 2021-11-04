using CQRS.Base.Command;
using PhotoStock.Sales.Domain.Client;
using PhotoStock.Sales.Domain.Offer;
using PhotoStock.Sales.Domain.Offer.Discount;
using PhotoStock.Sales.Domain.Reservation;
using PhotoStock.System;

namespace PhotoStock.Sales.Application.Services.OrderingService
{


  internal class CalculateOfferCommandHandler : IQueryHandler<Offer, CalculateOfferCommand>
  {
    private readonly IReservationRepository _reservationRepository;
    private readonly IDiscountFactory _discountFactory;
    private readonly IClientRepository _clientRepository;
    private readonly ISystemContext _systemContext;

    public CalculateOfferCommandHandler(ISystemContext systemContext, IClientRepository clientRepository, IDiscountFactory discountFactory, IReservationRepository reservationRepository)
    {
      _systemContext = systemContext;
      _clientRepository = clientRepository;
      _discountFactory = discountFactory;
      _reservationRepository = reservationRepository;
    }

    public Offer Handle(CalculateOfferCommand command)
    {
      Reservation reservation = _reservationRepository.Get(command.OrderId);

      IDiscountPolicy discountPolicy = _discountFactory.Create(LoadClient());

      return reservation.CalculateOffer(discountPolicy);
    }

    private Client LoadClient()
    {
      return _clientRepository.Get(_systemContext.SystemUser.ClientId);
    }
  }
}