using System.Data.SqlClient;
using AdoNet;
using AdoNet.Builders;
using AdoNet.Models;


var product = new Product()
{
    Name = "Chocolate",
    Description = "Malkovoe",
    Height = 3,
    Weight = 33,
    Width = 12,
    Length = 22,

};

var productRepository = new ProductRepository(ConfigConstants.connectionString);

//productRepository.Add(product);

var productFromDb = productRepository.Get(1003);

Console.WriteLine(productFromDb);

//productRepository.GetAll().ForEach(e=> Console.WriteLine(e));

var order = new Order()
{
    CreatedDate = DateTime.Now,
    ProductId = 1005,
    Status = OrderStatus.Cancelled,
};

var orderRepository = new OrderRepository(ConfigConstants.connectionString);

orderRepository.Add(order);
orderRepository.Add(order);
orderRepository.Add(order);
orderRepository.Add(order);

var orderFromDb = orderRepository.Get(1002);

orderRepository.Update(orderFromDb);

//Console.WriteLine(orderRepository.Get(1002));

//orderRepository.GetAll().ForEach(e => Console.WriteLine(e));

//productRepository.Delete(1003);

//orderRepository.FilterBy(OrderStatus.NotStarted, 1005).ForEach(e => Console.WriteLine(e));

orderRepository.FilterByQuery(new OrderFilterBuilder().AddStatus(OrderStatus.NotStarted).AddProductId(1005).Build()).ForEach(e => Console.WriteLine(e));

orderRepository.DeleteBulkByStatuses(OrderStatus.InProgress, OrderStatus.Cancelled);
