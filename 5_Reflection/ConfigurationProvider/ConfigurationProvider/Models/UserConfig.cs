using ConfigurationProvider.Attributes;
using Microsoft.Extensions.Configuration;

namespace ConfigurationProvider
{
    public class UserConfig : ConfigurationComponentBase
    {
        [FileConfigurationItem("FirstName", Constants.FilePath)]
        public string FirstName { get; set; }

        [FileConfigurationItem]
        public string SurName { get; set; }

        [FileConfigurationItem("PhoneNumber", Constants.FilePath)]
        public int Phone { get; set; }

        [FileConfigurationItem("DateBirth")]
        public DateTime Date { get; set; }

        [FileConfigurationItem("FloatNumber", Constants.FilePath)]
        public float FloatNumber { get; set; }

        public override string? ToString()
        {
            return $"UserConfig -- {FirstName} {SurName} || {Phone} || {Date.ToString("dd.MM.yyyy")} || {FloatNumber}";
        }
    }
}
