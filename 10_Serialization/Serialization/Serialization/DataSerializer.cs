using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Serialization
{
    internal class DataSerializer
    {
        public void BinarySerialize(object data, string filePath)
        {
            FileStream fileStream;
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            if(File.Exists(filePath)) File.Delete(filePath);

            fileStream = File.Create(filePath);
            binaryFormatter.Serialize(fileStream, data); 
            fileStream.Close();
        }

        public object BinaryDesirialize(string filePath)
        {
            object obj = null;

            FileStream fileStream;
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            if (File.Exists(filePath))
            {
                fileStream = File.OpenRead(filePath);
                obj = binaryFormatter.Deserialize(fileStream);
                fileStream.Close();
            }

            return obj;
        }

        public void XmlSerialize(Type dataType, object data, string filePath)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(dataType);

            if (File.Exists(filePath)) File.Delete(filePath);
            TextWriter textWriter = new StreamWriter(filePath);
            xmlSerializer.Serialize(textWriter, data);

            textWriter.Close();
        }

        public object XmlDeserialize(Type dataType, string filePath)
        {
            object obj = null;

            XmlSerializer xmlSerializer = new XmlSerializer(dataType);

            if (File.Exists(filePath))
            {
                TextReader textReader = new StreamReader(filePath);
                obj = xmlSerializer.Deserialize(textReader);
                textReader.Close();
            }

                return obj;
        }

        public void JsonSerialize(object data, string filePath)
        {
            JsonSerializer jsonSerializer = new JsonSerializer();

            if (File.Exists(filePath)) File.Delete(filePath);

            StreamWriter streamWriter = new StreamWriter(filePath);
            JsonWriter jsonWriter = new JsonTextWriter(streamWriter);

            jsonSerializer.Serialize(jsonWriter, data);

            jsonWriter.Close();
            streamWriter.Close();
        }

        public object JsonDeserialize(Type datatype, string filePath)
        {
            JObject obj = null;
            JsonSerializer jsonSerializer = new JsonSerializer();
            if (File.Exists(filePath))
            {
                StreamReader streamReader = new StreamReader (filePath);
                JsonReader jsonReader = new JsonTextReader(streamReader);

                obj = jsonSerializer.Deserialize(jsonReader) as JObject;

                streamReader.Close();
                jsonReader.Close();
            }

            return obj.ToObject(datatype);
        }
    }
}
