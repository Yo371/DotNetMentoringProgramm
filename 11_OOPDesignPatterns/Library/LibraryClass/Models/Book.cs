using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryClass.Attributes;

namespace Library.Models
{
    //attribute [Cacheable (no expiration TimeSpan)]
    // Helper.IsCacheable(LibraryItem) ? GetTimeSpan(LibaryItem). IsMarkedByAttribute(Libraryitem, typeof(Cacheable))
    [Cacheable(1, Measure.Minutes)]
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
