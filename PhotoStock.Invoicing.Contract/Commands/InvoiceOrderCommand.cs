using DDD.Base.Domain;
using PhotoStock.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoStock.Invoicing.Contract.Commands
{
  public class InvoiceOrderCommand
  {
    public AggregateId OrderId { get; set; }
    public ClientData ClientData { get; set; }
    public IEnumerable<OrderItem> Items { get; set; }

    public InvoiceOrderCommand(AggregateId orderId, ClientData clientData, IEnumerable<OrderItem> items)
    {
      OrderId = orderId;
      ClientData = clientData;
      Items = items;
    }
  }
}