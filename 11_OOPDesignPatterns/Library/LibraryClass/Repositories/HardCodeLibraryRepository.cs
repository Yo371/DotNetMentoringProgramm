using Library.Models;
using LibraryClass.Models;

namespace LibraryClass.Repositories
{
    public class HardCodeLibraryRepository : ILibraryRepository <LibraryItem>
    {
        private List<LibraryItem> _libraryItems;

        public HardCodeLibraryRepository()
        {
            InitializeLibraryItems();
        }

        private void InitializeLibraryItems()
        {
            _libraryItems = new List<LibraryItem>()
            {
                new LocalizedBook()
                {
                    Authors = new List<Author>() { new() { FirstName = "Firstname", LastName = "Surname" } },
                    CountryOfLocalization = "Hangury",
                    ISBN = 123123,
                    LocalPublisher = "Azbuka",
                    NumberOfPages = 440,
                    OriginalPublisher = "Originalazbuka",
                    PublishDate = new DateTime(2002, 12, 10),
                    Title = "Master"
                },
                new LocalizedBook()
                {
                    Authors = new List<Author>() { new() { FirstName = "Firstname2", LastName = "Surname2" } },
                    CountryOfLocalization = "Hangury2",
                    ISBN = 12323,
                    LocalPublisher = "Azbuka2",
                    NumberOfPages = 440,
                    OriginalPublisher = "Originalazbuka2",
                    PublishDate = new DateTime(2022, 2, 10),
                    Title = "Master2"
                },
                new Book()
                {
                    Authors = new List<Author>() { new() { FirstName = "Firstname3", LastName = "Surname3" } },
                    ISBN = 34234,
                    NumberOfPages = 40,
                    OriginalPublisher = "Original1",
                    PublishDate = new DateTime(2012, 12, 14),
                    Title = "Book"
                },
                new Book()
                {
                    Authors = new List<Author>() { new() { FirstName = "Firstname4", LastName = "Surname4" } },
                    ISBN = 34234,
                    NumberOfPages = 40,
                    OriginalPublisher = "Original4",
                    PublishDate = new DateTime(2012, 12, 14),
                    Title = "Book4"
                },
                new Book()
                {
                    Authors = new List<Author>()
                    {
                        new() { FirstName = "Firstname5", LastName = "Surname5" },
                        new() { FirstName = "SecondName", LastName = "SecondLastname" }
                    },
                    ISBN = 34234,
                    NumberOfPages = 40,
                    OriginalPublisher = "Original5",
                    PublishDate = new DateTime(2012, 12, 14),
                    Title = "Book5"
                },
                new Patent()
                {
                    Authors = new List<Author>() { new() { FirstName = "Firstname0", LastName = "Surname0" } },
                    PublishDate = new DateTime(2012, 12, 14),
                    Title = "Patent1",
                    ExpireDate =  new DateTime(2012, 12, 14),
                    UniqueId = Guid.NewGuid()
                },
                new Patent()
                {
                    Authors = new List<Author>() { new() { FirstName = "Firstname00", LastName = "Surname00" } },
                    PublishDate = new DateTime(2012, 12, 14),
                    Title = "Patent2",
                    ExpireDate =  new DateTime(2012, 12, 14),
                    UniqueId = Guid.NewGuid()
                },

            };
        }

        public List<LibraryItem> GetAll()
        {
            return _libraryItems;
        }

        public void Update(List<LibraryItem> list) => _libraryItems.AddRange(list);

        }
}
