using DDD.Base.Domain;
using PhotoStock.SharedKernel;
using System.Collections.Generic;

namespace PhotoStock.Invoicing.Domain
{
  public class Invoice : AggregateRoot
  {
    public ClientData Client { get; private set; }
    public Money Net { get; private set; }
    public Money Gros { get; private set; }
    public List<InvoiceLine> _items = new List<InvoiceLine>();

    public Invoice(AggregateId invoiceId, ClientData client) : base(invoiceId)
    {
      Client = client;
      Net = Money.ZERO;
      Gros = Money.ZERO;
    }

    private Invoice()
    {
    }

    public void AddItem(InvoiceLine item)
    {
      _items.Add(item);

      Net = Net.Add(item.Net);
      Gros = Gros.Add(item.Gros);
    }
  }
}