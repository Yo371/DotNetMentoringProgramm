using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore.Storage;

namespace WebApi.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public byte[] Picture { get; set; }
    }
}
