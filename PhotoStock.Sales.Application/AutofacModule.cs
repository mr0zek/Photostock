using Autofac;
using PhotoStock.Sales.Domain.Offer.Discount;
using PhotoStock.Sales.Domain.Purchase;
using PhotoStock.Sales.Domain.Reservation;

namespace PhotoStock.Sales.Application
{
  public class AutofacModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterAssemblyTypes(typeof(ICommandHandler<>).Assembly)
        .AsClosedTypesOf(typeof(ICommandHandler<>)).AsImplementedInterfaces()
        .InstancePerLifetimeScope();
      builder.RegisterType<ReservationFactory>().AsImplementedInterfaces();
      builder.RegisterType<DiscountFactory>().AsImplementedInterfaces();
      builder.RegisterType<PurchaseFactory>().AsImplementedInterfaces();
      builder.RegisterType<PurchaseFactory>().AsImplementedInterfaces();
    }
  }
}