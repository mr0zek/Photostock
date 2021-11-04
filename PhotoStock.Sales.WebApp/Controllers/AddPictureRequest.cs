namespace PhotoStock.Sales.WebApp.Controllers
{
  public class AddPictureRequest
  {
    public string PictureId { get; set; }
    public int Quantity { get; internal set; }
  }
}