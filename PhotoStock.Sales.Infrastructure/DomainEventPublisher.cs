using System;
using System.Collections.Generic;
using DDD.Base.Domain;
using PhotoStock.Sales.Domain.Client;
using PhotoStock.Sales.Domain.Purchase;
using PhotoStock.Sales.Domain.Reservation;
using PhotoStock.Sales.Query.Events;

namespace PhotoStock.Sales.Infrastructure
{
  public class DomainEventPublisher : IDomainEventPublisher
  {
    private IPurchaseRepository _purchaseRepository;
    private IDictionary<Type, Func<IDomainEvent, object>> _handlers = new Dictionary<Type, Func<IDomainEvent, object>>();
    private IClientRepository _clientRepository;
    private IEventsRepository _eventsRepository;

    public DomainEventPublisher(IClientRepository clientRepository, IPurchaseRepository purchaseRepository, IEventsRepository eventsRepository)
    {
      _clientRepository = clientRepository;
      _purchaseRepository = purchaseRepository;
      _eventsRepository = eventsRepository;
      _handlers[typeof(ReservationCreatedEvent)] = f => ReservationCreatedHandler(f as ReservationCreatedEvent);
      _handlers[typeof(PurchaseConfirmedEvent)] = f => PurchaseConfirmedHandler(f as PurchaseConfirmedEvent);
    }

    private object PurchaseConfirmedHandler(PurchaseConfirmedEvent purchaseConfirmedEvent)
    {
      Purchase purchase = _purchaseRepository.Get(purchaseConfirmedEvent.PurchaseId);
      OrderConfirmedEventBuilder builder = new OrderConfirmedEventBuilder(_clientRepository);
      purchase.Export(builder);
      return builder.Build();
    }

    private object ReservationCreatedHandler(ReservationCreatedEvent f)
    {
      return new OrderCreatedEvent(f.AggregateId);
    }

    public void Publish<T>(T domainEvent) where T : IDomainEvent
    {
      object result = _handlers[typeof(T)](domainEvent);

      _eventsRepository.Add(result);
    }
  }
}