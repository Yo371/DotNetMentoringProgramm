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
    public class DapperOrderRepository
    {
        private string _connectionString;

        public const string getAllQuery = "SELECT * FROM Orders";
        public const string getByIdQuery = "SELECT * FROM Orders Ord INNER JOIN Product Pr ON Ord.ProductId = Pr.Id WHERE Ord.Id = {0}";
        public const string addQuery = "INSERT INTO dbo.Orders (Status, CreatedDate, ProductId) values (@Status, @CreatedDate, @ProductId)";
        public const string updatelQuery = "UPDATE dbo.Orders SET Status=@Status, UpdatedDate=@UpdatedDate WHERE Id = @Id";
        public const string deleteQuery = "DELETE FROM dbo.Orders WHERE Id = @Id";
        public const string DeleteOrdersByStatusBulkQuery = "DELETE FROM dbo.Orders WHERE Status in ({0})";

        public DapperOrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Order> GetAll()
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Order>(getAllQuery).ToList();
            }

            return null;
        }

        public Order Get(int id)
        {
            Order order = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                var restult = connection.Query<Order>(string.Format(getByIdQuery, id));
                order = restult.FirstOrDefault();
            }

            return order;
        }

        public Order Add(Order order)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
              
                connection.Execute(addQuery, new
                {
                    Status = order.Status.ToString(),
                    CreatedDate = order.CreatedDate,
                    ProductId = order.ProductId,
                });
            }

            return order;
        }

        public Order Update(Order order)
        {

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(updatelQuery, new
                {
                    Id = order.Id,
                    Status = order.Status.ToString(),
                    UpdatedDate = order.UpdatedDate,
                });
            }

            return order;
        }

        public void Delete(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Execute(deleteQuery, new { id });
            
        }

        public List<Order> Filter(string query)
        {
            using var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection.Query<Order>(query).ToList();
        }

        public void DeleteBulkByStatuses(params OrderStatus[] statuses)
        {
            var readyStatuses = statuses.Select(e => "'" + e + "'").ToList();

            var paramsForQuery = string.Join(", ", readyStatuses);

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                connection.Execute(string.Format(DeleteOrdersByStatusBulkQuery, paramsForQuery));
            }
        }
    }
}
