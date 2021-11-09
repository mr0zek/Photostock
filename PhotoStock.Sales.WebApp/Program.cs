using System;
using System.Threading.Tasks;

namespace PhotoStock.Sales.WebApp
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Bootstrap.Run(args, builder => { }, 12121);
      while (true)
      {
        Task.Delay(1000).Wait();
      }
    }
  }
}
