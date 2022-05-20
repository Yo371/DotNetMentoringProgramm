using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace Serialization
{
    public class DataSerializer
    {
        public void BinarySerialize(object data, string filePath)
        {
            var binaryFormatter = new BinaryFormatter();

            if (File.Exists(filePath)) File.Delete(filePath);

            using var fileStream = File.Create(filePath);

            binaryFormatter.Serialize(fileStream, data);
        }

        public object BinaryDesirialize(string filePath)
        {
            object obj = null;

            if (File.Exists(filePath))
            {
                using var fileStream = File.OpenRead(filePath);
                var binaryFormatter = new BinaryFormatter();
                obj = binaryFormatter.Deserialize(fileStream);
            }

            return obj;
        }

        public void XmlSerialize(Type dataType, object data, string filePath)
        {
            var xmlSerializer = new XmlSerializer(dataType);

            if (File.Exists(filePath)) File.Delete(filePath);

            using TextWriter textWriter = new StreamWriter(filePath);

            xmlSerializer.Serialize(textWriter, data);
        }

        public object XmlDeserialize(Type dataType, string filePath)
        {
            object obj = null;

            if (File.Exists(filePath))
            {
                using TextReader textReader = new StreamReader(filePath);

                var xmlSerializer = new XmlSerializer(dataType);
                obj = xmlSerializer.Deserialize(textReader);
            }
            return obj;
        }

        public void JsonSerialize(object data, string filePath)
        {
            var jsonSerializer = new JsonSerializer();

            if (File.Exists(filePath)) File.Delete(filePath);

            using StreamWriter streamWriter = new StreamWriter(filePath);
            using JsonWriter jsonWriter = new JsonTextWriter(streamWriter);

            jsonSerializer.Serialize(jsonWriter, data);
        }

        public object JsonDeserialize(Type datatype, string filePath)
        {
            JObject obj = null;
            
            if (File.Exists(filePath))
            {
                using StreamReader streamReader = new StreamReader (filePath);
                using JsonReader jsonReader = new JsonTextReader(streamReader);

                var jsonSerializer = new JsonSerializer();
                obj = jsonSerializer.Deserialize(jsonReader) as JObject;
            }

            return obj?.ToObject(datatype);
        }
    }
}
