using System;
using System.Collections.Generic;
using DDD.Base.Domain;
using PhotoStock.Sales.Domain.Client;
using PhotoStock.Sales.Domain.Purchase;
using PhotoStock.Sales.Domain.Reservation;
using PhotoStock.Sales.Query.Events;

namespace PhotoStock.Sales.Infrastructure.Events
{
  public class DomainEventPublisher : IDomainEventPublisher
  {
    private readonly IPurchaseRepository _purchaseRepository;
    private readonly IDictionary<Type, Func<IDomainEvent, EventDto>> _handlers = new Dictionary<Type, Func<IDomainEvent, EventDto>>();
    private readonly IClientRepository _clientRepository;
    private readonly IEventRepository _eventsRepository;

    public DomainEventPublisher(IClientRepository clientRepository, IPurchaseRepository purchaseRepository)
    {
      _clientRepository = clientRepository;
      _purchaseRepository = purchaseRepository;
      _handlers[typeof(ReservationCreatedEvent)] = f => ReservationCreatedHandler(f as ReservationCreatedEvent);
      _handlers[typeof(PurchaseConfirmedEvent)] = f => PurchaseConfirmedHandler(f as PurchaseConfirmedEvent);
    }

    private EventDto PurchaseConfirmedHandler(PurchaseConfirmedEvent purchaseConfirmedEvent)
    {
      Purchase purchase = _purchaseRepository.Get(purchaseConfirmedEvent.PurchaseId);
      OrderConfirmedEventBuilder builder = new OrderConfirmedEventBuilder(_clientRepository);
      purchase.Export(builder);
      return builder.Build();
    }

    private EventDto ReservationCreatedHandler(ReservationCreatedEvent f)
    {
      return new OrderCreatedEventDto(f.AggregateId, f.Version);
    }

    public void Publish<T>(T domainEvent) where T : IDomainEvent
    {
      EventDto result = _handlers[typeof(T)](domainEvent);
      
      _eventsRepository.Add(result);
    }
  }
}