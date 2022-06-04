using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdoNet.Extensions;
using AdoNet.Models;

namespace AdoNet
{
    public class ProductRepository
    {

        //constr (connection string) Repository
        //method SqlDataReader extension ToProduct(), ToOrder()
        //isolations level db

        private string _connectionString;

        public const string AddProductQuery = "INSERT INTO dbo.Product (Name, Description, Weight, Height, Width, Length) values (@Name, @Description, @Weight, @Height, @Width, @Length)";

        public const string UpdateProductQuery = "UPDATE dbo.Product SET Name=@Name, Description=@Description, Weight=@Weight, Height=@Height, Width=@Width, Length=@Length WHERE Id = {0}";

        public const string GetProductQuery = "SELECT * FROM Product WHERE Id = {0}";

        public const string DeleteProductQuery = "DELETE FROM dbo.Product WHERE Id = {0}";

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    //queries constants
                    command.CommandText = AddProductQuery;

                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Description", product.Description);
                    command.Parameters.AddWithValue("@Weight", product.Weight);
                    command.Parameters.AddWithValue("@Height", product.Height);
                    command.Parameters.AddWithValue("@Width", product.Width);
                    command.Parameters.AddWithValue("@Length", product.Length);

                    command.ExecuteNonQuery();
                }
            }

        }

        public void Update(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = string.Format(UpdateProductQuery, product.Id);


                    command.Parameters.AddWithValue("@Name", product.Name);
                    command.Parameters.AddWithValue("@Description", product.Description);
                    command.Parameters.AddWithValue("@Weight", product.Weight);
                    command.Parameters.AddWithValue("@Height", product.Height);
                    command.Parameters.AddWithValue("@Width", product.Width);
                    command.Parameters.AddWithValue("@Length", product.Length);

                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }

        }
 
        public Product Get(int id)
        {
            Product product = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = string.Format(GetProductQuery, id);

                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        //Console.WriteLine($"Product {dataReader["Id"]} - {dataReader["Name"]} {dataReader["Description"]} {dataReader["Weight"]} {dataReader["Height"]} {dataReader["Width"]} {dataReader["Length"]}");
                        product = dataReader.ToProduct();
                    }

                    dataReader.Close();
                }
            }

            return product;
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = string.Format(DeleteProductQuery, id);

                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public List<Product> GetAll()
        {
            List<Product> products = new List<Product>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Product";

                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        products.Add(dataReader.ToProduct());
                        //Console.WriteLine($"Product {dataReader["Id"]} - {dataReader["Name"]} {dataReader["Description"]} {dataReader["Weight"]} {dataReader["Height"]} {dataReader["Width"]} {dataReader["Length"]}");
                    }
                    dataReader.Close();
                }
            }

            return products;
        }
    }
}
