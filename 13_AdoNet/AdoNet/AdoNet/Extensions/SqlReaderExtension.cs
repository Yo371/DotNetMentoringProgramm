using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoNet.Models;

namespace AdoNet.Extensions
{
    public static class SqlReaderExtension
    {
        public static Product ToProduct(this SqlDataReader dataReader)
        {
            return new Product()
            {
                Id = int.Parse(dataReader["Id"].ToString()),
                Name = dataReader["Name"].ToString(),
                Description = dataReader["Description"].ToString(),
                Weight = int.Parse(dataReader["Weight"].ToString()),
                Height = int.Parse(dataReader["Height"].ToString()),
                Width = int.Parse(dataReader["Width"].ToString()),
                Length = int.Parse(dataReader["Length"].ToString()),
            };
        }

        public static Order ToOrder(this SqlDataReader dataReader)
        {
            return new Order()
            {
                Id = int.Parse(dataReader["Id"].ToString()),
                ProductId = int.Parse(dataReader["ProductId"].ToString()),
                CreatedDate = DateTime.Parse(dataReader["CreatedDate"].ToString()),
                UpdatedTime = dataReader["UpdatedDate"] == null ? DateTime.Parse(dataReader["UpdatedDate"].ToString()) : null,
            };
        }
    }
}
