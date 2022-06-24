using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HTTPproject.Client
{
    [TestClass]
    public class Program
    {
    
        /*async static Task Main(string[] args)
        {

                 test();
            //await GetMyNameAsync(client);
      
            Console.ReadKey();
        }

        static async Task GetMyNameAsync(HttpClient client)
        {
            var result = await client.GetAsync("https://localhost:7288/api/products");
            

            Console.WriteLine(await result.Content.ReadAsStringAsync());
        }*/

        [TestMethod]
        public async Task test()
        {
            using var client = new HttpClient();

            var result = await client.GetAsync("https://localhost:5001/api/products");


            Console.WriteLine(await result.Content.ReadAsStringAsync());
            Assert.IsTrue(true);
        }
    }
}