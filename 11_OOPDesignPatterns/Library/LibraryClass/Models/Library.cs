using Library.Models;
using LibraryClass.Helpers;
using LibraryClass.Repositories;
using LibraryClass.Services;

namespace LibraryClass.Models
{
    public class Library
    {
        public Dictionary<Guid, Card> Items { get; set; }

        private ILibraryRepository<LibraryItem> _repository;

        public Library(ILibraryRepository<LibraryItem> repository)
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

            if (resultItem != null) return resultItem;

            resultItem = Items[guid];

            if(resultItem != null && CacheHelper.IsCacheable(resultItem)) CacheService.Instance.AddToCache(new()
            {
                Item = resultItem,
                CreationDate = DateTime.Now
            });

            return resultItem;
        }

        public void AddItem(LibraryItem item)
        {
            var guid = Guid.NewGuid();
            Items.Add(guid, new Card()
            {
                LibraryItem = item,
                NumberOfCard = guid
            });
        }
    }
    
    public class Card
    {
        public LibraryItem LibraryItem { get; set; }

        public Guid NumberOfCard { get; set; }

        public string GetInfo()
        {
            return $"Card [{NumberOfCard}] with {LibraryItem.GetInfo()}";
        }
    }
}
