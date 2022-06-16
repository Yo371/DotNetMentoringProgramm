using System.Net;
using System.Text;

namespace ListenerProject.Listener
{
    public class RequestListener
    {
        public static void GetMyName(HttpListenerResponse response)
        {
            WriteResponseCode(response, "My Name");
        }

        public static void Information(HttpListenerResponse response)
        {
            string text = (int)HttpStatusCode.SwitchingProtocols + " - Information";
            response.StatusCode = (int)HttpStatusCode.SwitchingProtocols;
            response.ProtocolVersion = new Version(1, 0);
            response.Headers["Upgrade"] = "foo/2";
            response.Headers["Connection"] = "upgrade";

            response.SendChunked = false;
            WriteResponseCode(response, text);
            Console.WriteLine("Information - " + HttpStatusCode.SwitchingProtocols);
        }

        public static void Success(HttpListenerResponse response)
        {
            string text = (int)HttpStatusCode.Accepted + " - Success";
            response.StatusCode = (int)HttpStatusCode.Accepted;
            WriteResponseCode(response, text);
            Console.WriteLine("Success - " + HttpStatusCode.Accepted);
        }

        public static void Redirection(HttpListenerResponse response)
        {
            string text = (int)HttpStatusCode.Ambiguous + " - Redirection";
            response.StatusCode = (int)HttpStatusCode.Ambiguous;
            WriteResponseCode(response, text);
            Console.WriteLine("Redirection - " + HttpStatusCode.Ambiguous.ToString());
        }

        public static void ClientError(HttpListenerResponse response)
        {
            string text = string.Concat(((int)HttpStatusCode.BadRequest).ToString(), " - Client Error");
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            WriteResponseCode(response, text);
            Console.WriteLine("Client Error - " + HttpStatusCode.BadRequest.ToString());
        }

        public static void ServerError(HttpListenerResponse response)
        {
            string text = (int)HttpStatusCode.BadGateway + " - Server Error";
            response.StatusCode = (int)HttpStatusCode.BadGateway;
            WriteResponseCode(response, text);
            Console.WriteLine("Server Error - " + HttpStatusCode.BadGateway);
        }

        public static void GetMyNameByHeader(HttpListenerResponse response)
        {
            var msg = new HttpRequestMessage(HttpMethod.Post, "http://localhost:8888/MyNameByHeader");
            response.Headers.Add("X-MyName", "Ivan");

            byte[] buffer = Encoding.UTF8.GetBytes("GetMyNameByHeader");
            response.ContentLength64 = buffer.Length;

            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
        }

        public static void GetMyNameByCookies(HttpListenerResponse response)
        {
            Cookie myName = new Cookie("MyName", "Ivan");
            response.AppendCookie(myName);
            WriteResponseCode(response, "");
            Console.WriteLine("Cookie - " + response.Cookies["MyName"].Value);
        }

        static void WriteResponseCode(HttpListenerResponse response, string text)
        {
            Console.WriteLine(text + " " + response.StatusCode);
            byte[] buffer = Encoding.UTF8.GetBytes(text);
            response.ContentLength64 = buffer.Length;

            Stream output = response.OutputStream;
            output.Write(buffer, 0, buffer.Length);
            output.Close();
            response.Close();
        }

        public static void GetFinish(HttpListenerResponse response)
        {
            WriteResponseCode(response, "End of server work");
            Console.WriteLine("End of work with connection");
        }
    }
}
