using System.Collections.Generic;
using System.Data.SqlClient;
using CQRS.Base.Query;
using Dapper;

namespace PhotoStock.Sales.Query.Offer
{
  class ProductFinder : IProductFinder
  {
    private readonly string _connectionString;

    public ProductFinder(string connectionString)
    {
      _connectionString = connectionString;
    }

    public PaginatedResult<ProductDto> GetPage(OfferQuery query)
    {
      SqlConnection connection = new SqlConnection(_connectionString);
      IEnumerable<ProductDto> items = connection.Query<ProductDto>("select data from Table1 where id = @id",new { id = 12 });
      PaginatedResult<ProductDto> result = new PaginatedResult<ProductDto>(items, 1,100,1000);
      return result;
    }
  }
}