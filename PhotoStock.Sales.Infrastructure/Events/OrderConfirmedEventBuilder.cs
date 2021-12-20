using System.Collections.Generic;
using DDD.Base.Domain;
using PhotoStock.Sales.Domain.Client;
using PhotoStock.Sales.Domain.Purchase;
using PhotoStock.Sales.Query.Events;
using PhotoStock.SharedKernel;

namespace PhotoStock.Sales.Infrastructure.Events
{
  internal class OrderConfirmedEventBuilder : IPurchaseExporter
  {
    private AggregateId _orderId;
    private ClientData _clientData;
    private IClientRepository _clientRepository;
    private List<OrderItemDto> _items = new List<OrderItemDto>();
    private int _version;

    public OrderConfirmedEventBuilder(IClientRepository clientRepository)
    {
      _clientRepository = clientRepository;
    }

    public void ExportItem(ProductData productData, Money totalCost)
    {
      _items.Add(new OrderItemDto() { ProductData = productData, TotalCost = totalCost });
    }

    public void ExportIdAndVersion(AggregateId purchaseId, int version)
    {
      _orderId = purchaseId;
      _version = version;
    }

    public void ExportClientId(AggregateId clientId)
    {
      _clientData = _clientRepository.Get(clientId).GenerateSnapshot();
    }

    public EventDto Build()
    {
      return new OrderConfirmedEventDto(_orderId, _clientData, _items, _version);
    }
  }
}