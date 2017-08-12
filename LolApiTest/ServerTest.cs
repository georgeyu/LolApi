using log4net;
using log4net.Config;
using LolApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net;
using System.Reflection;
using System.IO;
using static LolApi.Api;

namespace LolApiTest
{
    [TestClass]
    public class ServerTest
    {
        private const string SummonerIDUrl = "https://na1.api.riotgames.com/lol/summoner/v3/summoners/by-name/concise?api_key=3d7ef075-ffb6-4757-a92d-f40df1a400ce";
        private const string ForbiddenUrl = "https://na1.api.riotgames.com/lol/summoner/v3/summoners/by-name/concise?api_key=3d7ef075-ffb6-4757-a92d-f40df1a400cf";
        private const string SummonerIDResponse = "{\"id\":21704191,\"accountId\":35174352,\"name\":\"Concise\",\"profileIconId\":2085,\"revisionDate\":1500771565000,\"summonerLevel\":30}";
        private const string Path = "Config.txt";
        private const string MatchNotFound = "1576020311";
        private static readonly MethodBase constructor = MethodBase.GetCurrentMethod();
        private static readonly ILog log = LogManager.GetLogger(constructor.DeclaringType);
        private readonly string key;

        public ServerTest()
        {
            XmlConfigurator.Configure();
            key = File.ReadAllText(Path);
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
                server.Respond(ForbiddenUrl);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(WebException))]
        public void Respond_MatchNotFound_WebException()
        {
            using (var client = new WebClient())
            {
                var server = new Server(client);
                var region = GetDescription(Region.NA);
                var urlWriter = new UrlWriter(region, key);
                var url = urlWriter.WriteMatchByMatch(MatchNotFound);
                server.Respond(url);
            }
        }
    }
}
