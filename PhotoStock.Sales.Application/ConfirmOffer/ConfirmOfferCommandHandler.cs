using PhotoStock.Sales.Application.Services.OrderingService;
using PhotoStock.Sales.Domain.Client;
using PhotoStock.Sales.Domain.Offer;
using PhotoStock.Sales.Domain.Offer.Discount;
using PhotoStock.Sales.Domain.Purchase;
using PhotoStock.Sales.Domain.Reservation;
using PhotoStock.System;

namespace PhotoStock.Sales.Application.ConfirmOffer
{
  internal class ConfirmOfferCommandHandler : ICommandHandler<ConfirmOfferCommand>
  {
    private readonly IClientRepository _clientRepository;
    private readonly ISystemContext _systemContext;
    private readonly IReservationRepository _reservationRepository;
    private readonly IDiscountFactory _discountFactory;
    private readonly IPurchaseFactory _purchaseFactory;
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly IOfferRepository _offerRepository;

    public ConfirmOfferCommandHandler(
      IPurchaseRepository purchaseRepository, 
      IPurchaseFactory purchaseFactory, 
      IDiscountFactory discountFactory, 
      IReservationRepository reservationRepository, 
      ISystemContext systemContext, 
      IClientRepository clientRepository, 
      IOfferRepository offerRepository)
    {
      _purchaseRepository = purchaseRepository;
      _purchaseFactory = purchaseFactory;
      _discountFactory = discountFactory;
      _reservationRepository = reservationRepository;
      _systemContext = systemContext;
      _clientRepository = clientRepository;
      _offerRepository = offerRepository;
    }

    public void Handle(ConfirmOfferCommand command)
    {
      Offer seenOffer = _offerRepository.Get(command.OfferId);
      Reservation reservation = _reservationRepository.Get(command.OrderId);
      Offer newOffer = reservation.CalculateOffer(_discountFactory.Create(LoadClient()));

      if (!newOffer.SameAs(seenOffer, 5))
      {
        throw new OfferChangedExcpetion(command.OrderId, seenOffer, newOffer);
      }

      Client client = LoadClient();

      if (!client.CanAfford(newOffer.TotalCost))
      {
        throw new NotEnoughMoneyException(newOffer.TotalCost);
      }

      client.Charge(newOffer.TotalCost);
      _clientRepository.Save(client);

      Purchase purchase = _purchaseFactory.Create(command.OrderId, client, newOffer);
      _purchaseRepository.Save(purchase);

      reservation.Close();
      _reservationRepository.Save(reservation);
    }

    private Client LoadClient()
    {
      return _clientRepository.Get(_systemContext.SystemUser.ClientId);
    }
  }
}