using log4net;
using log4net.Config;
using LolApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Reflection;

namespace LolApiTest
{
    [TestClass]
    public class ServerTest
    {
        private const string SummonerIDUrl = "https://na1.api.riotgames.com/lol/summoner/v3/summoners/by-name/concise?api_key=3d7ef075-ffb6-4757-a92d-f40df1a400ce";
        private const string ForbiddenUrl = "https://na1.api.riotgames.com/lol/summoner/v3/summoners/by-name/concise?api_key=3d7ef075-ffb6-4757-a92d-f40df1a400cf";
        private const string SummonerIDResponse = "{\"id\":21704191,\"accountId\":35174352,\"name\":\"Concise\",\"profileIconId\":2085,\"revisionDate\":1500771565000,\"summonerLevel\":30}";
        private static readonly MethodBase constructor = MethodBase.GetCurrentMethod();
        private static readonly ILog log = LogManager.GetLogger(constructor.DeclaringType);

        public ServerTest()
        {
            XmlConfigurator.Configure();
        }

        [TestMethod]
        public void Respond_SummonerID_Response()
        {
            using (var client = new WebClient())
            {
                var server = new Server(client);
                var response = server.Respond(SummonerIDUrl);
                Assert.AreEqual(response, SummonerIDResponse);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(WebException))]
        public void Respond_Forbidden_WebException()
        {
            using (var client = new WebClient())
            {
                var server = new Server(client);
                var response = server.Respond(ForbiddenUrl);
            }
        }
    }
}
