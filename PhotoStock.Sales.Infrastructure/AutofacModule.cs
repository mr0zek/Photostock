using Autofac;
using PhotoStock.Sales.Infrastructure.Events;

namespace PhotoStock.Sales.Infrastructure
{
  public class AutofacModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<InMemoryClientRepository>().AsImplementedInterfaces();
      builder.RegisterType<InMemoryOfferRepository>().AsImplementedInterfaces();
      builder.RegisterType<InMemoryReservationRepository>().AsImplementedInterfaces();
      builder.RegisterType<InMemoryProductRepository>().AsImplementedInterfaces();
      builder.RegisterType<InMemoryPurchaseRepository>().AsImplementedInterfaces();
      builder.RegisterType<OrderConfirmedEventBuilder>().AsImplementedInterfaces();
      builder.RegisterType<InMemoryEventRepository>().AsImplementedInterfaces();
      builder.RegisterType<DomainEventPublisher>().AsImplementedInterfaces();
    }
  }
}