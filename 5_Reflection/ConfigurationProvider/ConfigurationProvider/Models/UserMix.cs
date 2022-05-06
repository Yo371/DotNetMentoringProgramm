using ConfigurationProvider.Attributes;

namespace ConfigurationProvider.Models
{
    public class UserMix : ConfigurationComponentBase
    {
        [FileConfigurationItem]
        public string FirstName { get; set; }

        [JsonConfigurationItem("SurName", Constants.JsonPath)]
        public string SurName { get; set; }

        [FileConfigurationItem("PhoneNumber")]
        public int Phone { get; set; }

        [FileConfigurationItem("DateBirth", Constants.FilePath)]
        public DateTime Date { get; set; }

        [JsonConfigurationItem]
        public float FloatNumber { get; set; }

        public override string? ToString()
        {
            return $"UserMix -- {FirstName} {SurName} || {Phone} || {Date.ToString("dd.MM.yyyy")} || {FloatNumber}";
        }
    }
}
