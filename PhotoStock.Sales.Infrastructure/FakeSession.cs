using NHibernate;
using NHibernate.Engine;
using NHibernate.Stat;
using NHibernate.Type;
using System;
using System.Data;
using System.Linq.Expressions;

namespace PhotoStock.Sales.Application
{
  public class FakeSession : ISession
  {
    public void Dispose()
    {
      throw new NotImplementedException();
    }

    public void Flush()
    {
      throw new NotImplementedException();
    }

    public IDbConnection Disconnect()
    {
      throw new NotImplementedException();
    }

    public void Reconnect()
    {
      throw new NotImplementedException();
    }

    public void Reconnect(IDbConnection connection)
    {
      throw new NotImplementedException();
    }

    public IDbConnection Close()
    {
      throw new NotImplementedException();
    }

    public void CancelQuery()
    {
      throw new NotImplementedException();
    }

    public bool IsDirty()
    {
      throw new NotImplementedException();
    }

    public bool IsReadOnly(object entityOrProxy)
    {
      throw new NotImplementedException();
    }

    public void SetReadOnly(object entityOrProxy, bool readOnly)
    {
      throw new NotImplementedException();
    }

    public object GetIdentifier(object obj)
    {
      throw new NotImplementedException();
    }

    public bool Contains(object obj)
    {
      throw new NotImplementedException();
    }

    public void Evict(object obj)
    {
      throw new NotImplementedException();
    }

    public object Load(Type theType, object id, LockMode lockMode)
    {
      throw new NotImplementedException();
    }

    public object Load(string entityName, object id, LockMode lockMode)
    {
      throw new NotImplementedException();
    }

    public object Load(Type theType, object id)
    {
      throw new NotImplementedException();
    }

    public T Load<T>(object id, LockMode lockMode)
    {
      throw new NotImplementedException();
    }

    public T Load<T>(object id)
    {
      throw new NotImplementedException();
    }

    public object Load(string entityName, object id)
    {
      throw new NotImplementedException();
    }

    public void Load(object obj, object id)
    {
      throw new NotImplementedException();
    }

    public void Replicate(object obj, ReplicationMode replicationMode)
    {
      throw new NotImplementedException();
    }

    public void Replicate(string entityName, object obj, ReplicationMode replicationMode)
    {
      throw new NotImplementedException();
    }

    public object Save(object obj)
    {
      throw new NotImplementedException();
    }

    public void Save(object obj, object id)
    {
      throw new NotImplementedException();
    }

    public object Save(string entityName, object obj)
    {
      throw new NotImplementedException();
    }

    public void Save(string entityName, object obj, object id)
    {
      throw new NotImplementedException();
    }

    public void SaveOrUpdate(object obj)
    {
      throw new NotImplementedException();
    }

    public void SaveOrUpdate(string entityName, object obj)
    {
      throw new NotImplementedException();
    }

    public void SaveOrUpdate(string entityName, object obj, object id)
    {
      throw new NotImplementedException();
    }

    public void Update(object obj)
    {
      throw new NotImplementedException();
    }

    public void Update(object obj, object id)
    {
      throw new NotImplementedException();
    }

    public void Update(string entityName, object obj)
    {
      throw new NotImplementedException();
    }

    public void Update(string entityName, object obj, object id)
    {
      throw new NotImplementedException();
    }

    public object Merge(object obj)
    {
      throw new NotImplementedException();
    }

    public object Merge(string entityName, object obj)
    {
      throw new NotImplementedException();
    }

    public T Merge<T>(T entity) where T : class
    {
      throw new NotImplementedException();
    }

    public T Merge<T>(string entityName, T entity) where T : class
    {
      throw new NotImplementedException();
    }

    public void Persist(object obj)
    {
      throw new NotImplementedException();
    }

    public void Persist(string entityName, object obj)
    {
      throw new NotImplementedException();
    }

    public void Delete(object obj)
    {
      throw new NotImplementedException();
    }

    public void Delete(string entityName, object obj)
    {
      throw new NotImplementedException();
    }

    public int Delete(string query)
    {
      throw new NotImplementedException();
    }

    public int Delete(string query, object value, IType type)
    {
      throw new NotImplementedException();
    }

    public int Delete(string query, object[] values, IType[] types)
    {
      throw new NotImplementedException();
    }

    public void Lock(object obj, LockMode lockMode)
    {
      throw new NotImplementedException();
    }

    public void Lock(string entityName, object obj, LockMode lockMode)
    {
      throw new NotImplementedException();
    }

    public void Refresh(object obj)
    {
      throw new NotImplementedException();
    }

    public void Refresh(object obj, LockMode lockMode)
    {
      throw new NotImplementedException();
    }

    public LockMode GetCurrentLockMode(object obj)
    {
      throw new NotImplementedException();
    }

    public ITransaction BeginTransaction()
    {
      throw new NotImplementedException();
    }

    public ITransaction BeginTransaction(IsolationLevel isolationLevel)
    {
      throw new NotImplementedException();
    }

    public ICriteria CreateCriteria<T>() where T : class
    {
      throw new NotImplementedException();
    }

    public ICriteria CreateCriteria<T>(string alias) where T : class
    {
      throw new NotImplementedException();
    }

    public ICriteria CreateCriteria(Type persistentClass)
    {
      throw new NotImplementedException();
    }

    public ICriteria CreateCriteria(Type persistentClass, string alias)
    {
      throw new NotImplementedException();
    }

    public ICriteria CreateCriteria(string entityName)
    {
      throw new NotImplementedException();
    }

    public ICriteria CreateCriteria(string entityName, string alias)
    {
      throw new NotImplementedException();
    }

    public IQueryOver<T, T> QueryOver<T>() where T : class
    {
      throw new NotImplementedException();
    }

    public IQueryOver<T, T> QueryOver<T>(Expression<Func<T>> alias) where T : class
    {
      throw new NotImplementedException();
    }

    public IQueryOver<T, T> QueryOver<T>(string entityName) where T : class
    {
      throw new NotImplementedException();
    }

    public IQueryOver<T, T> QueryOver<T>(string entityName, Expression<Func<T>> alias) where T : class
    {
      throw new NotImplementedException();
    }

    public IQuery CreateQuery(string queryString)
    {
      throw new NotImplementedException();
    }

    public IQuery CreateFilter(object collection, string queryString)
    {
      throw new NotImplementedException();
    }

    public IQuery GetNamedQuery(string queryName)
    {
      throw new NotImplementedException();
    }

    public ISQLQuery CreateSQLQuery(string queryString)
    {
      throw new NotImplementedException();
    }

    public void Clear()
    {
      throw new NotImplementedException();
    }

    public object Get(Type clazz, object id)
    {
      throw new NotImplementedException();
    }

    public object Get(Type clazz, object id, LockMode lockMode)
    {
      throw new NotImplementedException();
    }

    public object Get(string entityName, object id)
    {
      throw new NotImplementedException();
    }

    public T Get<T>(object id)
    {
      throw new NotImplementedException();
    }

    public T Get<T>(object id, LockMode lockMode)
    {
      throw new NotImplementedException();
    }

    public string GetEntityName(object obj)
    {
      throw new NotImplementedException();
    }

    public IFilter EnableFilter(string filterName)
    {
      throw new NotImplementedException();
    }

    public IFilter GetEnabledFilter(string filterName)
    {
      throw new NotImplementedException();
    }

    public void DisableFilter(string filterName)
    {
      throw new NotImplementedException();
    }

    public IMultiQuery CreateMultiQuery()
    {
      throw new NotImplementedException();
    }

    public ISession SetBatchSize(int batchSize)
    {
      throw new NotImplementedException();
    }

    public ISessionImplementor GetSessionImplementation()
    {
      throw new NotImplementedException();
    }

    public IMultiCriteria CreateMultiCriteria()
    {
      throw new NotImplementedException();
    }

    public ISession GetSession(EntityMode entityMode)
    {
      throw new NotImplementedException();
    }

    public EntityMode ActiveEntityMode { get; private set; }
    public FlushMode FlushMode { get; set; }
    public CacheMode CacheMode { get; set; }
    public ISessionFactory SessionFactory { get; private set; }
    public IDbConnection Connection { get; private set; }
    public bool IsOpen { get; private set; }
    public bool IsConnected { get; private set; }
    public bool DefaultReadOnly { get; set; }
    public ITransaction Transaction { get; private set; }
    public ISessionStatistics Statistics { get; private set; }
  }
}