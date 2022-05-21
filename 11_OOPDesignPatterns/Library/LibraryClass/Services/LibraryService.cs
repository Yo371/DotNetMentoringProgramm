using Library.Models;
using LibraryClass.Helpers;
using LibraryClass.Models;
using LibraryClass.Repositories;

namespace LibraryClass.Services
{
    public class LibraryService
    {
        public Dictionary<Guid, Card> Items { get; set; }

        private ILibraryRepository<LibraryItem> _repository;

        public LibraryService(ILibraryRepository<LibraryItem> repository)
        {
            _repository = repository;
            Items = new Dictionary<Guid, Card>();
        }

        public Dictionary<Guid, Card> LoadItems()
        {
            for (int i = 0; i < _repository.GetAll().Count; i++)
            {
                var guid = Guid.NewGuid();
                Items.Add(guid, new Card()
                {
                    LibraryItem = _repository.GetAll()[i],
                    NumberOfCard = guid
                });
            }

            return Items;
        }

        public Card GetCardByNumber(Guid guid)
        {
            var resultItem = CacheService.Instance.GetCachedItem(guid)?.Item;

            if (resultItem != null)
            {
                Console.WriteLine("Returned from cache");
                return resultItem;
            }

            resultItem = Items[guid];

            if (resultItem != null && CacheHelper.IsCacheable(resultItem.LibraryItem))
            {
                Console.WriteLine("Added to cache");
                CacheService.Instance.AddToCache(new()
                {
                    Item = resultItem,
                    CreationDate = DateTime.Now
                });
            }

            Console.WriteLine("Returned from origin");
            return resultItem;
        }

        public void AddItem(LibraryItem item, Guid guid)
        {
            Items.Add(guid, new Card()
            {
                LibraryItem = item,
                NumberOfCard = guid
            });
        }
    }
}
