using DDD.Base.Domain;
using Moq;
using NUnit.Framework;
using PhotoStock.Invoicing.Contract.Events;
using PhotoStock.Sales.Contract.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoStock.BusinessProcess.Sagas;

namespace PhotoStock.BusinessProcess.Tests
{
  [TestFixture]
  public class OrderSagaManagerTests
  {
    private InMemorySagaRepository<OrderSagaData> _repository;
    private Mock<ICommandSender> _commandSender;
    private OrderSagaManager _manager;

    [SetUp]
    public void Setup()
    {
      _repository = new InMemorySagaRepository<OrderSagaData>();
      _commandSender = new Mock<ICommandSender>();
      _manager = new OrderSagaManager(_repository, _commandSender.Object);
    }

    [Test]
    public void RaiseEvent_Should_write_to_db_saga_contents()
    {
      // Arrange
      const string orderId = "1";
      var orderConfirmedEvent = new OrderCreatedEvent(orderId);

      // Act
      _manager.ProcessMessage(orderConfirmedEvent);

      // Assert
      Assert.IsTrue(_repository.Values.ContainsKey(orderConfirmedEvent.OrderId));
      Assert.IsTrue(orderId == _repository.Values[orderId].OrderId);
    }

    //[Test]
    //public void OrderInvoicedEvent_Should_write_fill_invoiceNumber_and_send_shipCommand()
    //{
    //  // Arrange
    //  const string invoiceNumber = "FV/233";
    //  const string orderId = "12";
    //  var orderInvoicedEvent = new OrderInvoicedEvent(orderId, invoiceNumber);

    //  _repository.Values[orderId] = new OrderSagaData()
    //  {
    //    OrderId = orderId,
    //    CurrentState = _manager.SagaMachine.OrderConfirmed
    //  };

    //  // Act
    //  _manager.ProcessMessage(orderInvoicedEvent);

    //  // Assert
    //  _commandSender.Verify(f => f.Send(It.Is<SendShipmentCommand>(d => d.OrderId == orderId)));
    //  Assert.IsTrue(invoiceNumber == _repository.Values[orderId].InvoiceNumber);
    //}
  }
}