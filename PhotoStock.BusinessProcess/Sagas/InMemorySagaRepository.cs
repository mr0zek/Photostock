using System.Collections.Generic;

namespace PhotoStock.BusinessProcess.Sagas
{
  public class InMemorySagaRepository<TSagaData> : ISagaRepository<TSagaData> where TSagaData : class
  {
    public Dictionary<string, TSagaData> Values = new Dictionary<string, TSagaData>();

    public void Save(string id, TSagaData sagaData)
    {
      Values[id] = sagaData;
    }

    public TSagaData Load(string id)
    {
      if (Values.ContainsKey(id))
      {
        return Values[id];
      }
      return null;
    }
  }
}