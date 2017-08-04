using System.Collections.Generic;

namespace LolApi
{
    internal class ChampionList
    {
        public Dictionary<string, Champion> Data { get; set; }

        public string Type { get; set; }

        public string Version { get; set; }
    }
}
