using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;

namespace LolApi
{
    public class Api
    {
        private readonly Server server;
        private readonly UrlWriter writer;

        public Api(WebClient client, Region region, string key)
        {
            server = new Server(client);
            var regionDescription = GetDescription(region);
            writer = new UrlWriter(regionDescription, key);
        }

        public enum Region
        {
            [Description("na1")]
            NA
        }

        public MatchList GetRankedRiftMatches(string summonerName)
        {
            var summonerUrl = writer.WriteSummoner(summonerName);
            var summonerJson = server.Respond(summonerUrl);
            var summoner = JsonConvert.DeserializeObject<Summoner>(summonerJson);
            var accountID = summoner.accountId.ToString();
            var matchListUrl = writer.WriteMatchByAccount(accountID, writer.rankedRiftQueues);
            var matchListJson = server.Respond(matchListUrl);
            return JsonConvert.DeserializeObject<MatchList>(matchListJson);
        }

        public Match GetMatch(string matchID)
        {
            var url = writer.WriteMatchByMatch(matchID);
            var json = server.Respond(url);
            return JsonConvert.DeserializeObject<Match>(json);
        }

        public Dictionary<int, string> GetChampionByID()
        {
            var url = writer.WriteStaticChampions();
            var json = server.Respond(url);
            var championList = JsonConvert.DeserializeObject<ChampionList>(json);
            return championList.Data.ToDictionary(x => x.Value.Id, x => x.Key);
        }

        private static string GetDescription<T>(T enumInstance)
        {
            var enumString = enumInstance.ToString();
            var enumType = typeof(T);
            var members = enumType.GetMember(enumString);
            var member = members.First();
            var descriptionType = typeof(DescriptionAttribute);
            var customAttributes = member.GetCustomAttributes(descriptionType, false);
            var customAttribute = customAttributes.First();
            var descriptionAttribute = (DescriptionAttribute)customAttribute;
            return descriptionAttribute.Description;
        }
    }
}
