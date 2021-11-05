using DDD.Base.Domain;
using NUnit.Framework;
using PhotoStock.Sales.WebApp;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoStock.Sales.Tests
{
  [TestFixture]
  public class IntegrationTests
  {
    [SetUp]
    public void Setup()
    {
      Bootstrap.Run(new string[] { }, builder => { }, 12121);
    }


    [Test]
    public async Task SuccessScenario()
    {
      ISalesApi proxy = RestEase.RestClient.For<ISalesApi>("http://localhost:12121");
      IEventsApi eventsProxy = RestClient.For<IEventsApi>("http://localhost:12121");

      string orderId = await proxy.CreateOrder();

      IEnumerable<Event> events = await eventsProxy.GetEvents(0,100);

      Assert.IsTrue(events.Count() == 1);

      await proxy.AddPicture(orderId, new { PictureId="1", Quantity = 1 });

      string offerId = await proxy.CreateOffer(orderId);

      await proxy.GetOffer(orderId,offerId);

      await proxy.ConfirmOffer(orderId, offerId);

      
      events = await eventsProxy.GetEvents(3,100);

      Assert.IsTrue(events.Count() == 1);

    }
  }
}