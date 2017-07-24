using LolApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LolApiTest
{
    [TestClass]
    public class UrlWriterTest
    {
        private const string SummonerUrl = "https://na1.api.riotgames.com/lol/summoner/v3/summoners/by-name/concise?api_key=123";
        private const string MatchByAccountUrl = "https://na1.api.riotgames.com/lol/match/v3/matchlists/by-account/456?queue=4&queue=420&api_key=123";
        private const string MatchByMatchUrl = "https://na1.api.riotgames.com/lol/match/v3/matches/456?api_key=123";
        private const string StaticChampsUrl = "https://na1.api.riotgames.com/lol/static-data/v3/champions?locale=en_US&dataById=false&api_key=123";
        private readonly UrlWriter urlWriter = new UrlWriter("na1", "123");

        [TestMethod]
        public void WriteSummoner_Concise_Write()
        {
            var url = urlWriter.WriteSummoner("concise");
            Assert.AreEqual(url, SummonerUrl);
        }

        [TestMethod]
        public void WriteMatchByAccount_ConciseRankedRiftSolo_Write()
        {
            var url = urlWriter.WriteMatchByAccount("456", urlWriter.rankedRiftSoloQueues);
            Assert.AreEqual(url, MatchByAccountUrl);
        }

        [TestMethod]
        public void WriteMatchByMatch_MatchID_Write()
        {
            var url = urlWriter.WriteMatchByMatch("456");
            Assert.AreEqual(url, MatchByMatchUrl);
        }

        [TestMethod]
        public void WriteStaticChamps_None_Write()
        {
            var url = urlWriter.WriteStaticChamps();
            Assert.AreEqual(url, StaticChampsUrl);
        }
    }
}
