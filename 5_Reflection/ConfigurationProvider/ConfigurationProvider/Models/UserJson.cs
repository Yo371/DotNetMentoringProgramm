using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConfigurationProvider.Attributes;

namespace ConfigurationProvider.Models
{
    public class UserJson : ConfigurationComponentBase
    {
        [JsonConfigurationItem]
        public string FirstName { get; set; }

        [JsonConfigurationItem("SurName", Constants.JsonPath)]
        public string SurName { get; set; }

        [JsonConfigurationItem("PhoneNumber", Constants.JsonPath)]
        public int Phone { get; set; }

        [JsonConfigurationItem("DateBirth", Constants.JsonPath)]
        public DateTime Date { get; set; }

        [JsonConfigurationItem]
        public float FloatNumber { get; set; }

        public override string? ToString()
        {
            return $"UserJson -- {FirstName} {SurName} || {Phone} || {Date.ToString("dd.MM.yyyy")} || {FloatNumber}";
        }
    }
}
