using log4net;
using System.Net;
using System.Reflection;
using System.Threading;

namespace LolApi
{
    internal class Server
    {
        private const int BadRequest = 400;
        private const int Unauthorized = 401;
        private const int Forbidden = 403;
        private const int NotFound = 404;
        private const int RateLimit = 429;
        private const int ServerError = 500;
        private const int ServiceUnavailable = 503;
        private const int SecsToMillisecs = 1000;
        private const int MinutesToSecs = 60;
        private static readonly MethodBase constructor = MethodBase.GetCurrentMethod();
        private static readonly ILog log = LogManager.GetLogger(constructor.DeclaringType);
        private readonly WebClient client;

        public Server(WebClient client)
        {
            this.client = client;
        }

        public string Respond(string url)
        {
            var responded = false;
            string response = "";
            while (!responded)
            {
                responded = TryDownload(url, out response);
            }
            return response;
        }

        private bool TryDownload(string url, out string response)
        {
            try
            {
                response = client.DownloadString(url);
                return true;
            }
            catch (WebException e)
            {
                var webResponse = (HttpWebResponse)e.Response;
                var statusCode = (int)webResponse.StatusCode;
                var exception = e.ToString();
                switch (statusCode)
                {
                    case BadRequest:
                    case Unauthorized:
                    case Forbidden:
                    case NotFound:
                        log.Fatal(exception);
                        log.Fatal(url);
                        throw e;
                    case RateLimit:
                        log.Error("Rate limit.");
                        log.Error(exception);
                        log.Error(url);
                        Thread.Sleep(SecsToMillisecs);
                        break;
                    case ServerError:
                        log.Error("Server error.");
                        log.Error(exception);
                        log.Error(url);
                        Thread.Sleep(SecsToMillisecs);
                        break;
                    case ServiceUnavailable:
                        log.Error("Service unavailable.");
                        log.Error(exception);
                        log.Error(url);
                        Thread.Sleep(MinutesToSecs * SecsToMillisecs);
                        break;
                    default:
                        log.FatalFormat("Status code {0} not handled.", statusCode);
                        log.Fatal(exception);
                        log.Fatal(url);
                        throw e;
                }
                response = "";
                return false;
            }
        }
    }
}
