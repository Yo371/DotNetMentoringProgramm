// See https://aka.ms/new-console-template for more information
using System.Reflection;
using System.Threading.Channels;
using ConfigurationProvider;
using ConfigurationProvider.Models;
using ConfigurationProvider.Utils;
using Microsoft.Extensions.Configuration;

ReflectionConfigHelper.LoadProvidersFromDll(PropertiesReader.AssemblyLocation + Constants.PluginsPath);


var user = new UserConfig()
{
    FirstName = "adsa",
    Phone = 123,
    SurName = "sdfsdf",
    FloatNumber = 11.3f,
    Date = new DateTime(2021, 11, 11)
};

user.LoadSettings();
user.SaveSettings();

Console.WriteLine(user);

var user2 = new UserJson()
{
    FirstName = "adsa",
    Phone = 123,
    SurName = "sdfsdf",
    FloatNumber = 12.3f,
    Date = new DateTime(2022, 12, 12)
};

user2.LoadSettings();
user2.SaveSettings();

Console.WriteLine(user2);

var user3 = new UserMix()
{
    FirstName = "adsa",
    Phone = 123,
    SurName = "sdfsdf",
    FloatNumber = 12.3f,
    Date = new DateTime(2022, 12, 12)
};

user3.LoadSettings();
user3.SaveSettings();

Console.WriteLine(user3);