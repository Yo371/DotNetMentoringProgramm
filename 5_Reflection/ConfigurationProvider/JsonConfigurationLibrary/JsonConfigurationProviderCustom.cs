using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json.Linq;

namespace JsonConfigurationLibrary
{
    public class JsonConfigurationProviderCustom : IConfigurationProvider
    {
        private string _path;
        private JObject _jsonData;
        public string PropForSecondConstructor { get; set; }

        public JsonConfigurationProviderCustom(string path)
        {
            _path = path;
        }

        public JsonConfigurationProviderCustom(string path, string propForSecondConstructor)
        {
            _path = path;
            PropForSecondConstructor = propForSecondConstructor;
        }

        public bool TryGet(string key, out string? value)
        {
            value = (string?)_jsonData[key];
            return !string.IsNullOrEmpty(value);
        }

        public void Set(string key, string? value)
        {
            Load();
            var jToken = _jsonData.SelectToken(key);
            jToken?.Replace(value);
            var updatedJsonString = _jsonData.ToString();
            File.WriteAllText(_path, updatedJsonString);
        }

        public IChangeToken GetReloadToken()
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
            try
            {
                _jsonData = JObject.Parse(File.ReadAllText(_path));
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine("File is not found");
                throw;
            }
        }

        public IEnumerable<string> GetChildKeys(IEnumerable<string> earlierKeys, string? parentPath)
        {
            throw new NotImplementedException();
        }
    }
}
