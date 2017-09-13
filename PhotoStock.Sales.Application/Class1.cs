using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotoStock.Sales.Application.Handlers;
using PhotoStock.Sales.Contract.Command;

namespace PhotoStock.Sales.Application
{
  class Bootstrap
  {
    public void Configure()
    {
      Bus.Bus.RegisterCommandHandler<AddPictureCommand, AddPictureCommandHandler>();
    }
  }
}
