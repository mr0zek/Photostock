using DDD.Base.Domain;

namespace PhotoStock.SharedKernel
{
  public class ClientData : ValueObject
  {
    public ClientData(AggregateId aggregateId, string name)
    {
      AggregateId = aggregateId;
      Name = name;
    }

    public AggregateId AggregateId { get; private set; }
    public string Name { get; private set; }
    public TaxNumber TaxNumber { get; set; }
    public Address Address { get; set; }
  }

  public class Address : ValueObject
  {
  }
}