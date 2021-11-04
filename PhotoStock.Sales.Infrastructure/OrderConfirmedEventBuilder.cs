using System.Collections.Generic;
using DDD.Base.Domain;
using PhotoStock.Sales.Domain.Client;
using PhotoStock.Sales.Domain.Purchase;
using PhotoStock.Sales.Query.Events;
using PhotoStock.SharedKernel;

namespace PhotoStock.Sales.Infrastructure
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
      _clientData = _clientRepository.Get(clientId).GenerateSnapshot();
    }

    public object Build()
    {
      return new OrderConfirmedEvent(_orderId, _clientData, _items);
    }
  }
}