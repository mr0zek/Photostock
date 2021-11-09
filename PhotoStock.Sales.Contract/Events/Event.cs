namespace PhotoStock.Sales.Contract.Events
{
  public class Event
  {
    public int Id { get; set; }
    public string Type { get; set; }
    public int Version { get; set; }
  }
}