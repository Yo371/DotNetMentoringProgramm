using System.Reflection;
using System.Xml;

namespace ConfigurationProvider.Utils
{
    public class PropertiesReader
    {
        public static string AssemblyLocation => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + Constants.RelativePathStart;

        public static string GetProperty(string name)
        {
            var doc = new XmlDocument();
            doc.Load(AssemblyLocation + Constants.PropertiesPath);
            var node = doc.SelectSingleNode($"//property[@name='{name}']");
            return node?.Attributes?["value"]?.Value ?? string.Empty;
        }
    }
}