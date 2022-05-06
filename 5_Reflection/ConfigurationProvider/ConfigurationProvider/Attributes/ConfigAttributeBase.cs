using System.Runtime.CompilerServices;

namespace ConfigurationProvider.Attributes
{
    public class ConfigAttributeBase : Attribute
    {
        public string? Key { get; set; }

        public string? Path { get; set; }

        public ConfigAttributeBase([CallerMemberName] string key = null)
        {
            Key = key;
        }

        public ConfigAttributeBase(string? key, string path)
        {
            Key = key;
            Path = path;
        }
    }
}
