using System.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using SystemConfigurationManager = System.Configuration.ConfigurationManager;

namespace FileConfigurationLibrary
{
    public class FileConfigurationProviderCustom : IConfigurationProvider
    {
        private string _path;
        public string PropForSecondConstructor { get; set; }

        public FileConfigurationProviderCustom(string path)
        {
            _path = path;
        }

        public FileConfigurationProviderCustom(string path, string propForSecondConstructor)
        {
            _path = path;
            PropForSecondConstructor = propForSecondConstructor;
        }

        public bool TryGet(string key, out string? value)
        {
            value = SystemConfigurationManager.AppSettings[key];
            return !string.IsNullOrEmpty(value);
        }

        public void Set(string key, string? value)
        {
            Load();
            var configuration = SystemConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            try
            {
                configuration.AppSettings.Settings[key].Value = value;
                configuration.Save();
                SystemConfigurationManager.RefreshSection("appSettings");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine($"'{key}' key is not exists");
                throw;
            }
        }

        public IChangeToken GetReloadToken()
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
            ConfigHelper.ChangeAppConfig(_path);
            if (!SystemConfigurationManager.AppSettings.HasKeys())
            {
                Console.WriteLine("File is not found");
                throw new FileNotFoundException();
            }
        }

        public IEnumerable<string> GetChildKeys(IEnumerable<string> earlierKeys, string? parentPath)
        {
            throw new NotImplementedException();
        }
    }
}
