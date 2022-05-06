using System.Runtime.CompilerServices;

namespace ConfigurationProvider.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class JsonConfigurationItemAttribute : ConfigAttributeBase
    {
        public JsonConfigurationItemAttribute([CallerMemberName] string key = null) : base(key)
        {
        }

        public JsonConfigurationItemAttribute(string? key, string path) : base(key, path)
        {
        }
    }
}
