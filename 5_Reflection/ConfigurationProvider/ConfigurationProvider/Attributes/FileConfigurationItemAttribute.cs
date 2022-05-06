using System.Runtime.CompilerServices;

namespace ConfigurationProvider.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FileConfigurationItemAttribute : ConfigAttributeBase
    {
        public FileConfigurationItemAttribute([CallerMemberName] string key = null) : base(key)
        {
        }

        public FileConfigurationItemAttribute(string? key, string path) : base(key, path)
        {
        }
    }
}
