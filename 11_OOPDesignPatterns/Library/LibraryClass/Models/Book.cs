using Library.Models;
using LibraryClass.Attributes;

namespace LibraryClass.Models
{
    [Cacheable(5, Measure.Seconds)]
    public class Book : LibraryItem
    {
        public int ISBN { get; set; }
        public int NumberOfPages { get; set; }
        public string OriginalPublisher{ get; set; }

        public override string GetInfo()
        {
            
            return $"Book - Title: {Title}, Authors: {GetAuthorsAsString()} PublishDate: {PublishDate.ToString("d")}, ISBN: {ISBN}" +
                   $", NumberOfPages: {NumberOfPages}, OriginalPublisher: {OriginalPublisher}";
        }
    }
}
