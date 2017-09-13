using DDD.Base.Domain;
using PhotoStock.Sales.Contract.Events;
using PhotoStock.Sales.Domain.Client;
using PhotoStock.Sales.Domain.Purchase;
using PhotoStock.Sales.Domain.Reservation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bus;

namespace Photostock.Sales.Infrastructure
{
  public class DomainEventPublisher : IDomainEventPublisher
  {
    private ISystemEventPublisher _systemEventPublisher;
    private IPurchaseRepository _purchaseRepository;
    private IDictionary<Type, Func<IDomainEvent, Bus.IEvent>> _handlers = new Dictionary<Type, Func<IDomainEvent, Bus.IEvent>>();
    private IClientRepository _clientRepository;

    public DomainEventPublisher(ISystemEventPublisher systemEventPublisher, IClientRepository clientRepository, IPurchaseRepository purchaseRepository)
    {
      _systemEventPublisher = systemEventPublisher;
      _clientRepository = clientRepository;
      _purchaseRepository = purchaseRepository;
      _handlers[typeof(ReservationCreatedEvent)] = f => ReservationCreatedHandler(f as ReservationCreatedEvent);
      _handlers[typeof(PurchaseConfirmedEvent)] = f => PurchaseConfirmedHandler(f as PurchaseConfirmedEvent);
    }

    private Bus.IEvent PurchaseConfirmedHandler(PurchaseConfirmedEvent purchaseConfirmedEvent)
    {
      Purchase purchase = _purchaseRepository.Load(purchaseConfirmedEvent.PurchaseId);
      OrderConfirmedEventBuilder builder = new OrderConfirmedEventBuilder(_clientRepository);
      purchase.Export(builder);
      return builder.Build();
    }

    private Bus.IEvent ReservationCreatedHandler(ReservationCreatedEvent f)
    {
      return new OrderCreatedEvent(f.AggregateId);
    }

    public void Publish<T>(T domainEvent) where T : IDomainEvent
    {
      Bus.IEvent result = _handlers[typeof(T)](domainEvent);
      _systemEventPublisher.Publish(result);
    }
  }
}