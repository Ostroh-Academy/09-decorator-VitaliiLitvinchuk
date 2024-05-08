using Newtonsoft.Json;
using System.Xml.Linq;

namespace Task
{
    internal class Program
    {
        public interface IDataConverter
        {
            string ConvertData(string data);
        }

        public class JsonToXmlConverter : IDataConverter
        {
            public string ConvertData(string jsonData)
            {
                return JsonConvert.DeserializeXNode(jsonData.Trim(), "Root").ToString();
            }
        }

        public class XmlToJsonConverter : IDataConverter
        {
            public string ConvertData(string xmlData)
            {
                return JsonConvert.SerializeXNode(XDocument.Parse(xmlData).Root);
            }
        }

        public class SerializeDecorator(IDataConverter converter)
        {
            private readonly IDataConverter _converter = converter;

            public string ConvertData(string data)
            {
                return _converter.ConvertData(data);
            }
        }
        static void Main(string[] args)
        {
            string json = @"{'name': 'John Doe', 'age': 30, 'city': 'New York'}";

            SerializeDecorator serialize = new SerializeDecorator(new JsonToXmlConverter());

            string xml = serialize.ConvertData(json);
            Console.WriteLine(xml);

            serialize = new SerializeDecorator(new XmlToJsonConverter());

            json = serialize.ConvertData(xml);
            Console.WriteLine(json);

        }
    }
}
