namespace PhotoStock.Sales.Query.Events
{
  public class EventDto
  {
    public int Id { get; set; }
    public string Type { get; set; }
    public int Version { get; set; }

<<<<<<< HEAD
    public EventDto(int version)
    {
      Type = this.GetType().ToString();
=======
    public EventDto(int version, string type)
    {
      Type = type;
>>>>>>> 93a0f79 (stage 5)
    }
  }
}