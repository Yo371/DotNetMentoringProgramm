using System.Data.SqlClient;
using DapperProject;
using DapperProject.DataAccess;
using DapperProject.Models;
using Microsoft.EntityFrameworkCore;

var product = new Product()
{
    Name = "Chocolate",
    Description = "Malkovoe",
    Height = 10,
    Weight = 10,
    Width = 10,
    Length = 10,

};

using var productContext = new ProductContext();
//add
/*productContext.Product.Add(product);

productContext.SaveChanges();*/

/*var productFromDb = productContext.Products.Where(e => e.Equals(product)).FirstOrDefault();

//update
productFromDb.Height = 333;
productContext.SaveChanges();

Console.WriteLine(productFromDb);*/

//delete
/*productContext.Remove(productFromDb);

productContext.SaveChanges();*/



var order = new Order()
{
    Status = OrderStatus.NotStarted,
    ProductId = 3003,
    CreatedDate = DateTime.Now,

};

//productContext.Orders.Add(order);

//productContext.SaveChanges();

//update
var orderFromDb = productContext.Orders.Where(e => e.Id == 2003).FirstOrDefault();

orderFromDb.Status = OrderStatus.InProgress;
orderFromDb.UpdatedDate = DateTime.Now;

productContext.SaveChanges();

//delete
/*var orderFromDb = productContext.Orders.Where(e => e.Id == 2002).FirstOrDefault();

productContext.Remove(orderFromDb);

productContext.SaveChanges();*/

var filteredList = productContext.Orders.Where(o => o.Status == OrderStatus.NotStarted).ToList();


