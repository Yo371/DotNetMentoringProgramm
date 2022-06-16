using System.Net;
using ListenerProject.Listener;

HttpListener listener = new HttpListener();

listener.Prefixes.Add("http://localhost:8888/Information/");
listener.Prefixes.Add("http://localhost:8888/Success/");
listener.Prefixes.Add("http://localhost:8888/Redirection/");
listener.Prefixes.Add("http://localhost:8888/ClientError/");
listener.Prefixes.Add("http://localhost:8888/ServerError/");
listener.Prefixes.Add("http://localhost:8888/MyName/");
listener.Prefixes.Add("http://localhost:8888/MyNameByHeader/");
listener.Prefixes.Add("http://localhost:8888/Finish/");
listener.Prefixes.Add("http://localhost:8888/MyNameByCookies/");

listener.Start();

Console.WriteLine("Waiting connections...");

string prefix;

bool flag = true;

while (flag)
{
    var context = listener.GetContext();
    var response = context.Response;

    prefix = context.Request.RawUrl;

    switch (prefix)
    {
        case "/MyName":
            RequestListener.GetMyName(response);
            break;
        case "/Information":
            RequestListener.Information(response);
            break;
        case "/Success":
            RequestListener.Success(response);
            break;
        case "/Redirection":
            RequestListener.Redirection(response);
            break;
        case "/ClientError":
            RequestListener.ClientError(response);
            break;
        case "/ServerError":
            RequestListener.ServerError(response);
            break;
        case "/MyNameByHeader":
            RequestListener.GetMyNameByHeader(response);
            break;
        case "/MyNameByCookies":
            RequestListener.GetMyNameByCookies(response);
            break;
        case "/Finish":
            RequestListener.GetFinish(response);
            listener.Stop();
            flag = false;
            break;
    }
}