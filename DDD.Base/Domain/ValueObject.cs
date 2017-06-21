using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DDD.Base.Domain
{
  public abstract class ValueObject : IEqualityComparer, IEquatable<ValueObject>
  {
    private const int Multiplier = 59;
    private const int StartValue = 17;

    public static bool operator ==(ValueObject x, ValueObject y)
    {
      if (ReferenceEquals(x, null) && ReferenceEquals(y, null))
      {
        return true;
      }

      if (ReferenceEquals(x, null))
      {
        return false;
      }

      return x.Equals(y);
    }

    public static bool operator !=(ValueObject x, ValueObject y)
    {
      return !(x == y);
    }

    public virtual bool Equals(ValueObject other)
    {
      if (other == null)
      {
        return false;
      }

      Type t = GetType();

      Type otherType = other.GetType();

      if (t != otherType)
      {
        return false;
      }

      FieldInfo[] fields = t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

      foreach (FieldInfo field in fields)
      {
        object value1 = field.GetValue(other);

        object value2 = field.GetValue(this);

        if (value1 == null)
        {
          if (value2 != null)
          {
            return false;
          }
        }
        else if (!value1.Equals(value2))
        {
          return false;
        }
      }

      return true;
    }

    public override bool Equals(object obj)
    {
      if (obj == null)
      {
        return false;
      }

      var other = obj as ValueObject;

      return Equals(other);
    }

    public override int GetHashCode()
    {
      IEnumerable<FieldInfo> fields = GetFields();

      int startValue = StartValue;

      int multiplier = Multiplier;

      int hashCode = startValue;

      foreach (FieldInfo field in fields)
      {
        object value = field.GetValue(this);

        if (value != null)
        {
          hashCode = (hashCode * multiplier) + value.GetHashCode();
        }
      }

      return hashCode;
    }

    private IEnumerable<FieldInfo> GetFields()
    {
      Type t = GetType();

      var fields = new List<FieldInfo>();

      while (t != typeof(object))
      {
        fields.AddRange(t.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public));

        t = t.BaseType;
      }

      return fields;
    }

    public new bool Equals(object x, object y)
    {
      if (ReferenceEquals(x, null) && ReferenceEquals(y, null))
      {
        return true;
      }

      if (ReferenceEquals(x, null))
      {
        return false;
      }

      return x.Equals(y);
    }

    public int GetHashCode(object obj)
    {
      return obj.GetHashCode();
    }
  }
}