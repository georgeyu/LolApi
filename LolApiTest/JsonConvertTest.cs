using log4net;
using log4net.Config;
using LolApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Reflection;

namespace LolApiTest
{
    [TestClass]
    public class JsonConvertTest
    {
        private const string Path = "Config.txt";
        private const string Summoner = "concise";
        private const string Account = "35174352";
        private const string Match = "2555167617";
        private static readonly MethodBase constructor = MethodBase.GetCurrentMethod();
        private static readonly ILog log = LogManager.GetLogger(constructor.DeclaringType);
        private readonly UrlWriter writer;

        public JsonConvertTest()
        {
            XmlConfigurator.Configure();
            var key = File.ReadAllText(Path);
            writer = new UrlWriter(Constants.Region, key);
        }

        [TestMethod]
        public void DeserializeObject_Summoner_Summoner()
        {
            var url = writer.WriteSummoner(Summoner);
            using (var client = new WebClient())
            {
                var server = new Server(client);
                var json = server.Respond(url);
                var summoner = JsonConvert.DeserializeObject<Summoner>(json);
            }
        }

        [TestMethod]
        public void DeserializeObject_MatchList_MatchList()
        {
            var url = writer.WriteMatchByAccount(Account, writer.rankedRiftSoloQueues);
            using (var client = new WebClient())
            {
                var server = new Server(client);
                var json = server.Respond(url);
                var matchList = JsonConvert.DeserializeObject<MatchList>(json);
            }
        }

        [TestMethod]
        public void DeserializeObject_Match_Match()
        {
            var url = writer.WriteMatchByMatch(Match);
            using (var client = new WebClient())
            {
                var server = new Server(client);
                var json = server.Respond(url);
                var match = JsonConvert.DeserializeObject<Match>(json);
            }
        }

        [TestMethod]
        public void DeserializeObject_Champion_Champion()
        {
            var url = writer.WriteStaticChamps();
            using (var client = new WebClient())
            {
                var server = new Server(client);
                var json = server.Respond(url);
                var championList = JsonConvert.DeserializeObject<ChampionList>(json);
            }
        }
    }
}
