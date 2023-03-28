using ProductShop.DTOs.Export;
using ProductShop.Models;
using System.Text;
using System.Xml.Serialization;

namespace ProductShop.Utilities
{
    public class XmlHelper
    {
        public T Deserialize<T>(string inputXml, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            using StringReader reader = new StringReader(inputXml);
            T deserializedObject = (T)xmlSerializer.Deserialize(reader);

            return deserializedObject;
        }

        public string Serialize<T>(T obj, string rootName)
        {
            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            StringBuilder sb = new StringBuilder();
            StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, obj, namespaces);

            return sb.ToString().TrimEnd();
        }

        public string Serialize<T>(T[] obj, string rootName)
        {
            StringBuilder sb = new StringBuilder();

            XmlRootAttribute xmlRoot = new XmlRootAttribute(rootName);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T[]), xmlRoot);

            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);
            xmlSerializer.Serialize(writer, obj, namespaces);

            return sb.ToString().TrimEnd();
        }
    }
}
