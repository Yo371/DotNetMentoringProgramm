// See https://aka.ms/new-console-template for more information


using Library.Models;
using LibraryClass.Attributes;
using LibraryClass.Helpers;
using LibraryClass.Models;

Console.WriteLine("Hello, World!");


LibraryItem libraryItem = new LocalizedBook()
{
    Authors = new List<Author>() {new(){FirstName = "Firstname", LastName = "Surname"}},
    CountryOfLocalization = "Hangury",
    ISBN = 123123,
    LocalPublisher = "Azbuka",
    NumberOfPages = 440,
    OriginalPublisher = "Originalazbuka",
    PublishDate = new DateTime(2002, 12, 10),
    Title = "Master"
};

LibraryItem book = new Book()
{
    Authors = new List<Author>() { new() { FirstName = "Firstname", LastName = "Surname" } },
    ISBN = 123123,
    NumberOfPages = 440,
    OriginalPublisher = "Originalazbuka",
    PublishDate = new DateTime(2002, 12, 10),
    Title = "Master"
};

LibraryItem patent = new Patent()
{
    Authors = new List<Author>() { new() { FirstName = "Firstname", LastName = "Surname" } },
    PublishDate = new DateTime(2002, 12, 10),
    Title = "Master"
};
//Console.WriteLine(CacheHelper.IsCacheable(patent));

Console.WriteLine(AttributeHelper.IsMarkedByAttribute(patent, typeof(CacheableAttribute)));

Console.WriteLine(CacheHelper.GetTimeout(patent));

/*Console.WriteLine(libraryItem.GetType().GetCustomAttributes(false).Select(e => e.GetType()).Any(e => e.Equals(typeof(CacheableAttribute))));
Console.WriteLine(patent.GetType().GetCustomAttributes(false).Any(e => e.Equals(typeof(CacheableAttribute))));*/

/*
string jsonFilePath = @"..\..\..\Data\Library.json";

var jsonRepository = new JsonLibraryRepository(jsonFilePath);


jsonRepository.Update(new HardCodeLibraryRepository().GetAll());

Console.WriteLine(jsonRepository.GetAll()[0].GetInfo());

Console.WriteLine( Guid.NewGuid());
*/




