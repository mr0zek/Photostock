using System;

namespace PhotoStock.Sales.WebApp
{
  public class Program
  {
    public static void Main(string[] args)
    {
      Bootstrap.Run(args, builder => { }, 12121);
      Console.ReadKey();
    }
  }
}
