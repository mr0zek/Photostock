namespace PhotoStock.Sales.Query.Events
{
  public class EventDto
  {
    public int Id { get; set; }
    public string Type { get; set; }
    public int Version { get; set; }

    public EventDto(int version)
    {
      Type = this.GetType().ToString();
    }
  }
}