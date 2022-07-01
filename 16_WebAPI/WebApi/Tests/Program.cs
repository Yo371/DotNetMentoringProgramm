using var client = new HttpClient();

var result = await client.GetAsync("https://localhost:7288/api/products");


Console.WriteLine(await result.Content.ReadAsStringAsync());


result = await client.GetAsync("https://localhost:7288/api/products/1");

Console.WriteLine(result.Content.ReadAsStringAsync());

result = await client.GetAsync("'https://localhost:7288/api/products?pageNumber=1&pageSize=10&categoryId=3'");

Console.WriteLine(result.Content.ReadAsStringAsync());
