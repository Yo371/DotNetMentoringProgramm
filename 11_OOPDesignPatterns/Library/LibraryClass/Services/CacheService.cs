using Library.Models;
using LibraryClass.Helpers;
using LibraryClass.Models;

namespace LibraryClass.Services
{
    internal class CacheService
    {

        private static CacheService _instance;

        public static CacheService Instance => _instance ?? (_instance = new CacheService());

        private CacheService()
        {
        }

        public Dictionary<Guid, CashedItem<Card>> CashedItems { get; set; } = new();

        public CashedItem<Card> GetCachedItem(Guid guid)
        {
            var cachedItem = CashedItems[guid];
            if (cachedItem != null && !IsExpired(cachedItem))
            {
                cachedItem.CreationDate = DateTime.Now;
                return cachedItem;
            }
            else if (cachedItem != null)
            {
                CashedItems.Remove(cachedItem.Item.NumberOfCard);
            }

            return null;
        }

        public bool IsExpired(CashedItem<Card> cachedItem) => (DateTime.Now - cachedItem.CreationDate).TotalSeconds > CacheHelper.GetTimeout(cachedItem.Item);

        public void AddToCache(CashedItem<Card> cachedItem) => CashedItems.Add(cachedItem.Item.NumberOfCard, cachedItem);
    }
}
