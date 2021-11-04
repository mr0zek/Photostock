using DDD.Base.Domain;
using System;

namespace PhotoStock.SharedKernel
{
  public class Date : ValueObject
  {
    private readonly DateTime _date;

    private Date(DateTime date)
    {
      _date = date.Date;
    }

    public static Date Today()
    {
      return new Date(DateTime.Today);
    }

    public static implicit operator Date(DateTime d) => new Date(d);

    public static explicit operator DateTime(Date d) => d._date;
  }
}