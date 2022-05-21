
using Library.Models;

namespace LibraryClass.Models
{
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
