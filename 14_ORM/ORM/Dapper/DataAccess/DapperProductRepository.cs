using DapperProject;
using DapperProject.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperProject.DataAccess
{
    public class DapperProductRepository
    {
        private string _connectionString;

        public const string AddProductQuery = "INSERT INTO dbo.Product (Name, Description, Weight, Height, Width, Length) values (@Name, @Description, @Weight, @Height, @Width, @Length)";

        public const string UpdateProductQuery = "UPDATE dbo.Product SET Name=@Name, Description=@Description, Weight=@Weight, Height=@Height, Width=@Width, Length=@Length WHERE Id = @Id";

        public const string GetProductQuery = "SELECT * FROM Product WHERE Id = {0}";

        public const string DeleteProductQuery = "DELETE FROM dbo.Product WHERE Id = @Id";

        public const string GetAllProductsQuery = "SELECT * FROM Product";
        /*public async Task<Product> Get(int id)
        {
            Product product = null;
            var sql = "SELECT * FROM Product WHERE Id = {0}";
            using (var connection = new SqlConnection(ConfigConstants.connectionString))
            {
                // connection.Open();
                var restult = await connection.QueryAsync<Product>(string.Format(sql, id));
                product = restult.FirstOrDefault();
            }

            return product;
        }*/

        public DapperProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Product> GetAll()
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Product>(GetAllProductsQuery).ToList();
        }

        public Product Get(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            return connection.Query<Product>(string.Format(GetProductQuery, id)).FirstOrDefault(); ;
        }

        public Product Add(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(AddProductQuery, product);
            }

            return product;
        }

        public Product Update(Product product)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(UpdateProductQuery, product);
            }

            return product;
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute(DeleteProductQuery, new { id });
        }
    }
}
