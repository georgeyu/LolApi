using System.Linq;

namespace LolApi
{
    internal class UrlWriter
    {
        private const string RankedSoloRift = "4";
        private const string RankedTeamRift = "42";
        private const string RankedTeamBuilderTeamRift = "410";
        private const string RankedTeamBuilderSoloRift = "420";
        private const string RankedFlexRift = "440";
        public readonly string rankedRiftQueues;
        public readonly string rankedRiftSoloQueues;
        private readonly string urlHead;
        private readonly string keyField;

        public UrlWriter(string region, string key)
        {
            rankedRiftQueues = GetQueueField(
                RankedSoloRift,
                RankedTeamRift,
                RankedTeamBuilderTeamRift,
                RankedTeamBuilderSoloRift,
                RankedFlexRift);
            rankedRiftSoloQueues = GetQueueField(RankedSoloRift, RankedTeamBuilderSoloRift);
            urlHead = string.Format("https://{0}.api.riotgames.com/lol", region);
            keyField = "api_key=" + key;
        }

        public string WriteSummoner(string summonerName)
        {
            return string.Format("{0}/summoner/v3/summoners/by-name/{1}?{2}", urlHead, summonerName, keyField);
        }

        public string WriteMatchByAccount(string accountID, string queues)
        {
            return string.Format(
                "{0}/match/v3/matchlists/by-account/{1}?{2}&{3}",
                urlHead,
                accountID,
                queues,
                keyField);
        }

        public string WriteMatchByMatch(string matchID)
        {
            return string.Format("{0}/match/v3/matches/{1}?{2}", urlHead, matchID, keyField);
        }

        public string WriteStaticChampions()
        {
            return string.Format("{0}/static-data/v3/champions?locale=en_US&dataById=false&{1}", urlHead, keyField);
        }

        public string WriteChampionMastery(string summonerID)
        {
            return string.Format("{0}/champion-mastery/v3/champion-masteries/by-summoner/{1}?{2}", urlHead, summonerID, keyField);
        }

        private string GetQueueField(params string[] queues)
        {
            var fields = queues.Select(x => "queue=" + x);
            return string.Join("&", fields);
        }
    }
}
