using CQRS.Base.Query;
using System.Collections.Generic;

namespace PhotoStock.Sales.Query.Offer
{
  public interface IProductFinder
  {
    PaginatedResult<ProductDto> GetPage(OfferQuery query);
  }
}