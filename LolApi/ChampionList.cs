using System.Collections.Generic;

namespace LolApi
{
    public class ChampionList
    {
        public Dictionary<string, Champion> Data { get; set; }

        public string Type { get; set; }

        public string Version { get; set; }
    }
}
