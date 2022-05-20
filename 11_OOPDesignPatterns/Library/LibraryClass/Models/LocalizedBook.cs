using Library.Models;
using LibraryClass.Attributes;

namespace LibraryClass.Models
{
    [Cacheable(Timeout.Infinite, Measure.Infinity)]
    public class LocalizedBook : Book
    {
        public string LocalPublisher { get; set; }
        public string CountryOfLocalization { get; set; }

        public override string GetInfo()
        {
            return $"LocalizedBook - Title: {Title}, Authors: {GetAuthorsAsString()}, PublishDate: {PublishDate.ToString("d")}, ISBN: {ISBN}" +
                   $", NumberOfPages: {NumberOfPages}, OriginalPublisher: {OriginalPublisher}, " +
                   $"LocalPublisher: {LocalPublisher}, CountryOfLocalization: {CountryOfLocalization}";
        }
    }
}
