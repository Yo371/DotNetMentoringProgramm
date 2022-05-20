using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Models
{
    public class Patent : LibraryItem
    {
        public DateTime ExpireDate { get; set; }

        public Guid UniqueId { get; set; }

        public override string GetInfo()
        {
            return $"Patent - Title: {Title}, Authors: {GetAuthorsAsString()} PublishDate: {PublishDate.ToString("d")}," +
                   $" ExpireDate: {ExpireDate.ToString("d")}, UniqueId: {UniqueId}";
        }
    }
}
