using System.Collections.Generic;
using DDD.Base.Domain;

namespace PhotoStock.Sales.Domain.ProductsCatalog
{
  public interface IProductRepository : IGenericRepository<Product>
  {
    //TODO : Query to different repository
    List<Product> FindProductWhereBestBeforeExpiredIn(int days);
  }
}