// See https://aka.ms/new-console-template for more information
using Library.Models;
using LibraryClass.Models;
using LibraryClass.Repositories;
using LibraryClass.Services;

string jsonFilePath = @"..\..\..\Data\Library.json";


LibraryItem localizedBook = new LocalizedBook()
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


var jsonRepository = new JsonLibraryRepository(jsonFilePath);

jsonRepository.Update(new HardCodeLibraryRepository().GetAll());

var library = new LibraryService(jsonRepository);
library.LoadItems();

Console.WriteLine("---- Check cacheable book with cache in 5 sec");

//add new book to library
library.AddItem(book, new Guid("33ed1a6a-d6f8-4a41-949b-0f4f68bbebb1"));

//get that book from library
var resultcard = library.GetCardByNumber(new Guid("33ed1a6a-d6f8-4a41-949b-0f4f68bbebb1"));
Console.WriteLine(resultcard.GetInfo());

//get that book from library again and book must be returned from cache
resultcard = library.GetCardByNumber(new Guid("33ed1a6a-d6f8-4a41-949b-0f4f68bbebb1"));
Console.WriteLine(resultcard.GetInfo());

//waiting for expiration from cache
Thread.Sleep(6000);

//get that book from library again and book must be returned from original collection
resultcard = library.GetCardByNumber(new Guid("33ed1a6a-d6f8-4a41-949b-0f4f68bbebb1"));
Console.WriteLine(resultcard.GetInfo());


Console.WriteLine("---- Check uncacheable patent");

library.AddItem(patent, new Guid("33ed1a6a-d6f8-4a41-949b-0f4f68bbebb2"));
resultcard = library.GetCardByNumber(new Guid("33ed1a6a-d6f8-4a41-949b-0f4f68bbebb2"));

Console.WriteLine(resultcard.GetInfo());

resultcard = library.GetCardByNumber(new Guid("33ed1a6a-d6f8-4a41-949b-0f4f68bbebb2"));

Console.WriteLine(resultcard.GetInfo());
Thread.Sleep(6000);

resultcard = library.GetCardByNumber(new Guid("33ed1a6a-d6f8-4a41-949b-0f4f68bbebb2"));

Console.WriteLine(resultcard.GetInfo());

Console.WriteLine("---- Check cacheable Localized book with infinity cache");

library.AddItem(localizedBook, new Guid("33ed1a6a-d6f8-4a41-949b-0f4f68bbebb3"));

resultcard = library.GetCardByNumber(new Guid("33ed1a6a-d6f8-4a41-949b-0f4f68bbebb3"));
Console.WriteLine(resultcard.GetInfo());

resultcard = library.GetCardByNumber(new Guid("33ed1a6a-d6f8-4a41-949b-0f4f68bbebb3"));
Console.WriteLine(resultcard.GetInfo());

Thread.Sleep(5000);

resultcard = library.GetCardByNumber(new Guid("33ed1a6a-d6f8-4a41-949b-0f4f68bbebb3"));
Console.WriteLine(resultcard.GetInfo());
resultcard = library.GetCardByNumber(new Guid("33ed1a6a-d6f8-4a41-949b-0f4f68bbebb3"));
Console.WriteLine(resultcard.GetInfo());















