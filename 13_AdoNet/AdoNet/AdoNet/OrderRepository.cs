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
    internal class OrderRepository
    {

        private string _connectionString;

        public const string AddOrderQuery =
            "INSERT INTO dbo.Orders (Status, CreatedDate, ProductId) values (@Status, @CreatedDate, @ProductId)";

        public const string UpdateOrderQuery =
            "UPDATE dbo.Orders SET Status=@Status, UpdatedDate=@UpdatedDate WHERE Id = {0}";

        public const string GetOrderQuery =
            "SELECT * FROM Orders Ord INNER JOIN Product Pr ON Ord.ProductId = Pr.Id WHERE Ord.Id = {0}";

        public const string DeleteOrderQuery = "DELETE FROM dbo.Orders WHERE Id = {0}";
        public const string DeleteOrdersByStatusBulkQuery = "DELETE FROM dbo.Orders WHERE Status in ({0})";

        public const string FilterUseSpQuery =
            "use Store exec dbo.OrderFilter @productId = {0}, @status = {1}";

        public OrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Order order)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = AddOrderQuery;

                    command.Parameters.AddWithValue("@Status", order.Status.ToString());
                    command.Parameters.AddWithValue("@CreatedDate", order.CreatedDate.ToString());
                    command.Parameters.AddWithValue("@ProductId", order.ProductId.ToString());

                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void Update(Order order)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = string.Format(UpdateOrderQuery, order.Id);

                    command.Parameters.AddWithValue("@Status", order.Status.ToString());
                    command.Parameters.AddWithValue("@UpdatedDate", order.UpdatedTime.ToString());

                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public void Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = string.Format(DeleteOrderQuery, id);

                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public Order Get(int id)
        {
            Order order = null;
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = string.Format(GetOrderQuery, id);

                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        order = dataReader.ToOrder();
                    }

                    dataReader.Close();
                }
            }
            return order;
        }

        public List<Order> GetAll()
        {
            List<Order> orders = new List<Order>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = "SELECT * FROM Orders";

                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        orders.Add(dataReader.ToOrder());
                    }
                    dataReader.Close();
                }
            }

            return orders;
        }

        public List<Order> FilterBy(OrderStatus? status, int? productId)
        {
            List<Order> orders = new List<Order>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = string.Format(FilterUseSpQuery, productId.ToString(), status.ToString());

                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        orders.Add(dataReader.ToOrder());
                    }

                    dataReader.Close();
                }
            }

            return orders;
        }

        public List<Order> FilterByQuery(string query)
        {
            List<Order> orders = new List<Order>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = query;

                    SqlDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        orders.Add(dataReader.ToOrder());
                    }

                    dataReader.Close();
                }
            }

            return orders;
        }

        public void DeleteBulkByStatuses(params OrderStatus[] statuses)
        {
            var readyStatuses = statuses.Select(e => "'" + e + "'").ToList();

            var paramsForQuery = string.Join(", ", readyStatuses);

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandText = string.Format(DeleteOrdersByStatusBulkQuery, paramsForQuery);

                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }
    }
}