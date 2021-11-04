using System.IO;
using System.Xml.Serialization;

namespace PhotoStock.BusinessProcess.Sagas
{
  public class SagaXmlSerilizer : ISerializer
  {
    public T Deserialize<T>(string serializedData) where T : class
    {
      using (StringReader sr = new StringReader(serializedData))
      {
        return new XmlSerializer(typeof(T)).Deserialize(sr) as T;
      }
    }

    public string Serialize(object sagaData)
    {
      using (StringWriter sw = new StringWriter())
      {
        new XmlSerializer(sagaData.GetType()).Serialize(sw, sagaData);
        return sw.GetStringBuilder().ToString();
      }
    }
  }
}