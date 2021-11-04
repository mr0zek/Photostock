using System;
using PhotoStock.Sales.Application.ConfirmOffer;
using PhotoStock.Sales.Domain.Client;
using PhotoStock.Sales.Domain.Offer;
using PhotoStock.Sales.Domain.Offer.Discount;
using PhotoStock.Sales.Domain.Reservation;
using PhotoStock.System;

namespace PhotoStock.Sales.Application.CalculateOffer
{


  internal class CalculateOfferCommandHandler : ICommandHandler<CalculateOfferCommand>
  {
    private readonly IReservationRepository _reservationRepository;
    private readonly IDiscountFactory _discountFactory;
    private readonly IClientRepository _clientRepository;
    private readonly ISystemContext _systemContext;
    private readonly IOfferRepository _offerRepository;

    public CalculateOfferCommandHandler(ISystemContext systemContext, IClientRepository clientRepository, IDiscountFactory discountFactory, IReservationRepository reservationRepository, IOfferRepository offerRepository)
    {
      _systemContext = systemContext;
      _clientRepository = clientRepository;
      _discountFactory = discountFactory;
      _reservationRepository = reservationRepository;
      _offerRepository = offerRepository;
    }

    public void Handle(CalculateOfferCommand command)
    {
      Reservation reservation = _reservationRepository.Get(command.OrderId);

      IDiscountPolicy discountPolicy = _discountFactory.Create(LoadClient());
      
      Offer offer = reservation.CalculateOffer(discountPolicy);
      
      _offerRepository.Save(command.OfferId, offer);
    }

    private Client LoadClient()
    {
      return _clientRepository.Get(_systemContext.SystemUser.ClientId);
    }
  }
}