using DDD.Base.Domain;
using PhotoStock.Sales.Contract.Events;
using PhotoStock.Sales.Domain.Client;
using PhotoStock.Sales.Domain.Purchase;
using PhotoStock.SharedKernel;
using System.Collections.Generic;

namespace Photostock.Sales.Infrastructure
{
  internal class OrderConfirmedEventBuilder : IPurchaseExporter
  {
    private AggregateId _orderId;
    private ClientData _clientData;
    private IClientRepository _clientRepository;
    private List<OrderItem> _items = new List<OrderItem>();

    public OrderConfirmedEventBuilder(IClientRepository clientRepository)
    {
      _clientRepository = clientRepository;
    }

    public void ExportItem(ProductData productData, Money totalCost)
    {
      _items.Add(new OrderItem() { ProductData = productData, TotalCost = totalCost });
    }

    public void ExportId(AggregateId purchaseId)
    {
      _orderId = purchaseId;
    }

    public void ExportClientId(AggregateId clientId)
    {
      _clientData = _clientRepository.Load(clientId).GenerateSnapshot();
    }

    public Bus.IEvent Build()
    {
      return new OrderConfirmedEvent(_orderId, _clientData, _items);
    }
  }
}