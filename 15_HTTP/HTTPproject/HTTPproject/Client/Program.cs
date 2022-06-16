using System.Net;

namespace HTTPproject.Client
{
    public class Program
    {
        async static Task Main(string[] args)
        {
            using var client = new HttpClient();

            await GetSuccessAsync(client);
            await GetRedirectionAsync(client);
            await GetClientErrorAsync(client);
            await GetServerErrorAsync(client);
            await GetMyNameAsync(client);
            await GetMyNameByHeaderAsync(client);
            await GetMyNameByCookesAsync(client);
            await GetInformationAsync(client);
            await GetFinishAsync(client);
            Console.ReadKey();
        }

        static async Task GetMyNameAsync(HttpClient client)
        {
            var result = await client.GetAsync("http://localhost:8888/MyName");
            string responseBody = await result.Content.ReadAsStringAsync();

            Console.WriteLine(responseBody);
        }

        static async Task GetInformationAsync(HttpClient client)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:8888/Information");
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                Console.WriteLine("Information status code: " + msg);
            }
        }

        static async Task GetSuccessAsync(HttpClient client)
        {
            var result = await client.GetAsync("http://localhost:8888/Success");
            Console.WriteLine("Success status code: " + (int)result.StatusCode);
        }

        static async Task GetRedirectionAsync(HttpClient client)
        {
            var result = await client.GetAsync("http://localhost:8888/Redirection");
            Console.WriteLine("Redirection status code: " + (int)result.StatusCode);
        }

        static async Task GetClientErrorAsync(HttpClient client)
        {
            var result = await client.GetAsync("http://localhost:8888/ClientError");
            Console.WriteLine("Client Error status code: " + (int)result.StatusCode);
        }

        static async Task GetServerErrorAsync(HttpClient client)
        {
            var result = await client.GetAsync("http://localhost:8888/ServerError");
            Console.WriteLine("Server Error status code: " + (int)result.StatusCode);
        }

        static async Task GetMyNameByHeaderAsync(HttpClient client)
        {
            var result = await client.GetAsync("http://localhost:8888/MyNameByHeader");
            await result.Content.ReadAsStringAsync();

            string str = result.Headers.GetValues("X-MyName").SingleOrDefault();
            Console.WriteLine("Get My Name By Header: " + str);
        }

        static async Task GetMyNameByCookesAsync(HttpClient client)
        {
            var response = await client.GetAsync("http://localhost:8888/MyNameByCookies");
            var cookie = response.Headers.GetValues("Set-Cookie").SingleOrDefault();
            Console.WriteLine("Cookie: " + cookie);
        }

        static async Task GetFinishAsync(HttpClient client)
        {
            var result = await client.GetAsync("http://localhost:8888/Finish");
            Console.WriteLine("Finish");
        }
    }
}