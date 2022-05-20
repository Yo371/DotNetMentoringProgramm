using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public abstract class LibraryItem
    {
        public string Title { get; set; }
        public List<Author> Authors { get; set; }

        public DateTime PublishDate { get; set; }

        protected string GetAuthorsAsString()
        {
            var authors = new StringBuilder();

            Authors.ForEach(e => authors.Append(e.GetAuthorString() + ", "));

            return authors.ToString();
        }

        public abstract string GetInfo();
    }

    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string GetAuthorString()
        {
            return FirstName + " " + LastName;
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return ((Author)obj).FirstName.Equals(FirstName) && ((Author)obj).LastName.Equals(LastName);
        }

    }
}
