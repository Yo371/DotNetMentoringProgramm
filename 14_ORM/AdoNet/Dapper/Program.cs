// See https://aka.ms/new-console-template for more information
using DapperProject.Models;
using DapperProject.DataAccess;
using DapperProject;
using DapperProject.Builders;

//Console.WriteLine(new DapperDataAccess().Get(2003));

var dataAccess = new DapperProductRepository(ConfigConstants.connectionString);

//dataAccess.GetAll().ForEach(x => Console.WriteLine(x));

//Console.WriteLine(dataAccess.Get(3003));

var product = new Product()
{
    Name = "DapperChocolateUpdated",
    Description = "DapperMalkovoe",
    Height = 10,
    Weight = 10,
    Width = 10,
    Length = 10,

};

product.Id = 3009;

//dataAccess.Add(product);

//dataAccess.Delete(1004);

//dataAccess.Update(product);

var order = new Order()
{
    Status = OrderStatus.NotStarted,
    ProductId = 3003,
    CreatedDate = DateTime.Now,

};

order.Id = 2007;
order.Status = OrderStatus.Loading;
order.UpdatedDate = DateTime.Now;

var orderDatRepository = new DapperOrderRepository(ConfigConstants.connectionString);

//orderDatRepository.Add(order);

//orderDatRepository.Delete(2006);

//orderDatRepository.Update(order);

var orderFromDb = orderDatRepository.Get(2007);

Console.WriteLine(orderFromDb);

var filteredList = orderDatRepository.Filter(new OrderFilterBuilder().AddStatus(OrderStatus.Loading).AddProductId(3003).Build());

orderDatRepository.DeleteBulkByStatuses(OrderStatus.Arrived, OrderStatus.Cancelled, OrderStatus.Done);