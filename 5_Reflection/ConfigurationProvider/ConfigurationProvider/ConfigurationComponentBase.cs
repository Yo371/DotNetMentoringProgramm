using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using ConfigurationProvider.Attributes;

namespace ConfigurationProvider
{
    public class ConfigurationComponentBase
    {
        private IEnumerable<PropertyInfo> GetPropertiesWithConfigAttr() => this.GetType().GetProperties()
            .Where(p => p.GetCustomAttributes(typeof(ConfigAttributeBase), true).Any());


        public void SaveSettings()
        {

            foreach (var propertyInfo in GetPropertiesWithConfigAttr())
            {
                var attr = propertyInfo.GetCustomAttribute<ConfigAttributeBase>(true);

                var configurationProvider = ProviderManager.GetConfigurationProvider(attr);

                configurationProvider.Set(attr.Key, propertyInfo.GetValue(this)?.ToString());
            }
        }

        public void LoadSettings()
        {
            foreach (var propertyInfo in GetPropertiesWithConfigAttr())
            {
                var attr = propertyInfo.GetCustomAttribute<ConfigAttributeBase>(true);

                var configurationProvider = ProviderManager.GetConfigurationProvider(attr);

                try
                {
                    configurationProvider.Load();
                    configurationProvider.TryGet(attr.Key, out var value);

                    if (value != null)
                    {
                        var propertyType = propertyInfo.PropertyType;
                        propertyInfo.SetValue(this, TryParse(propertyType, value));
                    }
                    else
                    {
                        Console.WriteLine($"'{attr.Key}' key is not exists");
                    }
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine("Configuration provider is not found in plugins directory");
                    throw;
                }
            }
        }

        private static object TryParse(Type type, string inValue)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(type);
            return converter.ConvertFromString(null, CultureInfo.InvariantCulture, inValue);
        }
    }
}
