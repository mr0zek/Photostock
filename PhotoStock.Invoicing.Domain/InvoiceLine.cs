using DDD.Base.Domain;
using PhotoStock.SharedKernel;

namespace PhotoStock.Invoicing.Domain
{
  public class InvoiceLine : Entity
  {
    public ProductData Product { get; private set; }
    public int Quantity { get; private set; }
    public Money Net { get; private set; }
    public Money Gros { get; private set; }
    public Tax Tax { get; private set; }

    public InvoiceLine()
    {
    }

    public InvoiceLine(ProductData product, int quantity, Money net, Tax tax)
    {
      Product = product;
      Quantity = quantity;
      Net = net;
      Tax = tax;
      Gros = Net.Add(tax.Amount);
    }
  }
}