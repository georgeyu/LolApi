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

        public MatchList GetRankedRiftMatchList(string summonerName)
        {
            var summoner = GetSummoner(summonerName);
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

        public IEnumerable<Champion> GetChampions()
        {
            var url = writer.WriteStaticChampions();
            var json = server.Respond(url);
            var championList = JsonConvert.DeserializeObject<ChampionList>(json);
            return championList.Data.Select(x => x.Value);
        }

        public Summoner GetSummoner(string name)
        {
            var url = writer.WriteSummoner(name);
            var json = server.Respond(url);
            return JsonConvert.DeserializeObject<Summoner>(json);
        }

        public IEnumerable<ChampionMastery> GetChampionMasteries(string summonerName)
        {
            var summoner = GetSummoner(summonerName);
            var id = summoner.id.ToString();
            var masteryUrl = writer.WriteChampionMastery(id);
            var masteryJson = server.Respond(masteryUrl);
            return JsonConvert.DeserializeObject<IEnumerable<ChampionMastery>>(masteryJson);
        }

        internal static string GetDescription<T>(T enumInstance)
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
