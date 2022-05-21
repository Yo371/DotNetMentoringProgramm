namespace LibraryClass.Models
{
    public class CashedItem<T>
    {
        public T Item { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
