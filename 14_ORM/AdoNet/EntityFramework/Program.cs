// See https://aka.ms/new-console-template for more information
using DapperProject.DataAccess;

Console.WriteLine("Hello, World!");

using var productContext = new ProductContext();

//productContext.Product.Add(product);

//productContext.SaveChanges();

var productFromDb = productContext.Products.Where(e => e.Id == 2003).FirstOrDefault();

productContext.SaveChanges();
