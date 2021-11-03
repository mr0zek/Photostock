using DDD.Base.Domain;
using System.Collections.Generic;

namespace PhotoStock.Sales.Domain.ProductsCatalog
{
  public interface IProductRepository : IGenericRepository<Product>
  {
    //TODO : Query to different repository
    List<Product> FindProductWhereBestBeforeExpiredIn(int days);
  }
}