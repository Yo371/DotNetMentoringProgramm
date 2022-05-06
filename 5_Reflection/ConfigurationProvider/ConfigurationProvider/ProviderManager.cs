using ConfigurationProvider.Attributes;
using ConfigurationProvider.Utils;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace ConfigurationProvider
{
    public class ProviderManager
    {
        public static IConfigurationProvider GetConfigurationProvider(Attribute attribute)
        {
            string path;
            if (attribute is FileConfigurationItemAttribute fileAttr)
            {
                path = PropertiesReader.AssemblyLocation + (string.IsNullOrEmpty(fileAttr.Path) ? PropertiesReader.GetProperty("FilePathConfig") : fileAttr.Path);
                return CreateProviderByNameFromDll("FileConfigurationProviderCustom", path, "string for Invoking Second Constructor");
            }

            if (attribute is JsonConfigurationItemAttribute jsonAttr)
            {
                path = PropertiesReader.AssemblyLocation + (string.IsNullOrEmpty(jsonAttr.Path) ? PropertiesReader.GetProperty("JsonPathConfig") : jsonAttr.Path);
                return CreateProviderByNameFromDll("JsonConfigurationProviderCustom", path);
            }

            //return default provider
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile(PropertiesReader.AssemblyLocation + PropertiesReader.GetProperty("JsonPathConfig"));
            IConfigurationSource configurationSource = new JsonConfigurationSource();
            return configurationSource.Build(configurationBuilder);
        }

        private static IConfigurationProvider CreateProviderByNameFromDll(string nameOfProvider, params object[] args) 
        {
            try
            {
                var instance = Activator.CreateInstance(ReflectionConfigHelper.ProvidersDictionary[nameOfProvider], args);
                return (IConfigurationProvider)instance;
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine($"{nameOfProvider} is not loaded");
                throw;
            }
        }

        //should be checked
        private static IConfigurationProvider CreateProviderByNameFromDllViaGetConstructors(string nameOfProvider, params object[] args) 
        {
            try
            {
                var constructors = ReflectionConfigHelper.ProvidersDictionary[nameOfProvider].GetConstructors();
                var constructor = constructors.Where(c => c.GetParameters().Select(p => p.GetType()).Equals(args.Select(e => e.GetType()))).First();
                var instance = (IConfigurationProvider)constructor?.Invoke(args)!;
                return instance;
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine($"{nameOfProvider} is not loaded");
                throw;
            }
        }
    }
}