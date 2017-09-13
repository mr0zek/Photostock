using System;
using System.Collections.Generic;

namespace CQRS.Base.Query
{
  public class PaginatedResult<T>
  {
    public List<T> Items { get; private set; }
    public int PageSize { get; private set; }
    public int PageNumber { get; private set; }
    public int PagesCount { get; private set; }
    public int TotalItemsCount { get; private set; }

    public PaginatedResult(int pageNumber, int pageSize)
    {
      PageNumber = pageNumber;
      PageSize = pageSize;
      Items = new List<T>();
      PagesCount = 0;
      TotalItemsCount = 0;
    }

    public PaginatedResult(List<T> items, int pageNumber, int pageSize, int totalItemsCount)
    {
      Items = items;
      PageNumber = pageNumber;
      PageSize = pageSize;
      PagesCount = CountPages(pageSize, totalItemsCount);
      TotalItemsCount = totalItemsCount;
    }

    private int CountPages(int size, int itemsCount)
    {
      return (int)Math.Ceiling((double)itemsCount / size);
    }
  }
}