using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocFlow.WebApp
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
