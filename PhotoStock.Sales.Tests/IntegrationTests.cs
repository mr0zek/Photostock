using NUnit.Framework;

namespace PhotoStock.Sales.Tests
{
  [TestFixture]
  public class IntegrationTests
  {
    [SetUp]
    public void Setup()
    {

    }


    [Test]
    public async void SuccessScenario()
    {
      ISalesApi proxy = RestEase.RestClient.For<ISalesApi>("http://localhost:12121");

      string orderId = await proxy.CreateOrder();

      await proxy.AddPicture(orderId, "1");

      string offerId = await proxy.CreateOffer(orderId);

      await proxy.GetOffer(offerId);

      await proxy.ConfirmOffer(offerId);
    }

  }
}