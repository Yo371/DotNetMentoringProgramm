using LibraryClass.Helpers;
using LibraryClass.Models;

namespace LibraryClass.Services
{
    public class CacheService
    {
        private static CacheService _instance;

        public static CacheService Instance => _instance ??= new CacheService();

        private CacheService()
        {
        }

        public Dictionary<Guid, CashedItem<Card>> CashedItems { get; set; } = new();

        public CashedItem<Card> GetCachedItem(Guid guid)
        {
            try
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
            }
            catch (KeyNotFoundException e)
            {
                Console.WriteLine("Card not found in cache, Card will return from origin");
            }
            
            return null;
        }

        //to helper
        public bool IsExpired(CashedItem<Card> cachedItem) =>
            CacheHelper.GetTimeout(cachedItem.Item.LibraryItem) != Timeout.Infinite && (DateTime.Now - cachedItem.CreationDate).TotalSeconds > CacheHelper.GetTimeout(cachedItem.Item.LibraryItem);


        public void AddToCache(CashedItem<Card> cachedItem) => CashedItems.Add(cachedItem.Item.NumberOfCard, cachedItem);
    }
}
