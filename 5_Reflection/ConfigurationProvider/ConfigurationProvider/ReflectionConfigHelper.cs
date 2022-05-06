using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace ConfigurationProvider
{
    public static class ReflectionConfigHelper
    {
        public static Dictionary<string, Type> ProvidersDictionary = new();

        public static void LoadProvidersFromDll(string pathToPlugns)
        {
            try
            {
                foreach (var plugin in Directory.GetFiles(pathToPlugns, "*.dll")) 
                {
                    var assembly = Assembly.LoadFrom(plugin);
                    foreach (var type in assembly.GetTypes())
                    {
                        if (type.GetInterfaces().Contains(typeof(IConfigurationProvider)))
                        {
                            ProvidersDictionary.Add(type.Name, type);
                        }
                    }
                }
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine("Directory with plugins not found");
                throw;
            }
        }
    }
}
