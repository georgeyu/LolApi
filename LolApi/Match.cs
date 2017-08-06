using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LolApi
{
    public class Ban
    {
        public int ID { get; set; }
        public int championId { get; set; }
        public int pickTurn { get; set; }
    }

    public class Team
    {
        public int ID { get; set; }
        public int teamId { get; set; }
        public string win { get; set; }
        public bool firstBlood { get; set; }
        public bool firstTower { get; set; }
        public bool firstInhibitor { get; set; }
        public bool firstBaron { get; set; }
        public bool firstDragon { get; set; }
        public bool firstRiftHerald { get; set; }
        public int towerKills { get; set; }
        public int inhibitorKills { get; set; }
        public int baronKills { get; set; }
        public int dragonKills { get; set; }
        public int vilemawKills { get; set; }
        public int riftHeraldKills { get; set; }
        public int dominionVictoryScore { get; set; }
        public List<Ban> bans { get; set; }
    }

    public class Mastery
    {
        public int ID { get; set; }
        public int masteryId { get; set; }
        public int rank { get; set; }
    }

    public class Rune
    {
        public int ID { get; set; }
        public int runeId { get; set; }
        public int rank { get; set; }
    }

    public class Stats
    {
        public int participantId { get; set; }
        public bool win { get; set; }
        public int item0 { get; set; }
        public int item1 { get; set; }
        public int item2 { get; set; }
        public int item3 { get; set; }
        public int item4 { get; set; }
        public int item5 { get; set; }
        public int item6 { get; set; }
        public int kills { get; set; }
        public int deaths { get; set; }
        public int assists { get; set; }
        public int largestKillingSpree { get; set; }
        public int largestMultiKill { get; set; }
        public int killingSprees { get; set; }
        public int longestTimeSpentLiving { get; set; }
        public int doubleKills { get; set; }
        public int tripleKills { get; set; }
        public int quadraKills { get; set; }
        public int pentaKills { get; set; }
        public int unrealKills { get; set; }
        public int totalDamageDealt { get; set; }
        public int magicDamageDealt { get; set; }
        public int physicalDamageDealt { get; set; }
        public int trueDamageDealt { get; set; }
        public int largestCriticalStrike { get; set; }
        public int totalDamageDealtToChampions { get; set; }
        public int magicDamageDealtToChampions { get; set; }
        public int physicalDamageDealtToChampions { get; set; }
        public int trueDamageDealtToChampions { get; set; }
        public int totalHeal { get; set; }
        public int totalUnitsHealed { get; set; }
        public int damageSelfMitigated { get; set; }
        public int damageDealtToObjectives { get; set; }
        public int damageDealtToTurrets { get; set; }
        public int visionScore { get; set; }
        public int timeCCingOthers { get; set; }
        public int totalDamageTaken { get; set; }
        public int magicalDamageTaken { get; set; }
        public int physicalDamageTaken { get; set; }
        public int trueDamageTaken { get; set; }
        public int goldEarned { get; set; }
        public int goldSpent { get; set; }
        public int turretKills { get; set; }
        public int inhibitorKills { get; set; }
        public int totalMinionsKilled { get; set; }
        public int neutralMinionsKilled { get; set; }
        public int neutralMinionsKilledTeamJungle { get; set; }
        public int neutralMinionsKilledEnemyJungle { get; set; }
        public int totalTimeCrowdControlDealt { get; set; }
        public int champLevel { get; set; }
        public int visionWardsBoughtInGame { get; set; }
        public int sightWardsBoughtInGame { get; set; }
        public int wardsPlaced { get; set; }
        public int wardsKilled { get; set; }
        public bool firstBloodKill { get; set; }
        public bool firstBloodAssist { get; set; }
        public bool firstTowerKill { get; set; }
        public bool firstTowerAssist { get; set; }
        public bool firstInhibitorKill { get; set; }
        public bool firstInhibitorAssist { get; set; }
        public int combatPlayerScore { get; set; }
        public int objectivePlayerScore { get; set; }
        public int totalPlayerScore { get; set; }
        public int totalScoreRank { get; set; }
    }

    public class CreepsPerMinDeltas
    {
        [JsonProperty(PropertyName = "10-20")]
        public double TenToTwenty { get; set; }
        [JsonProperty(PropertyName = "0-10")]
        public double ZeroToTen { get; set; }
    }

    public class XpPerMinDeltas
    {
        [JsonProperty(PropertyName = "10-20")]
        public double TenToTwenty { get; set; }
        [JsonProperty(PropertyName = "0-10")]
        public double ZeroToTen { get; set; }
    }

    public class GoldPerMinDeltas
    {
        [JsonProperty(PropertyName = "10-20")]
        public double TenToTwenty { get; set; }
        [JsonProperty(PropertyName = "0-10")]
        public double ZeroToTen { get; set; }
    }

    public class CsDiffPerMinDeltas
    {
        [JsonProperty(PropertyName = "10-20")]
        public double TenToTwenty { get; set; }
        [JsonProperty(PropertyName = "0-10")]
        public double ZeroToTen { get; set; }
    }

    public class XpDiffPerMinDeltas
    {
        [JsonProperty(PropertyName = "10-20")]
        public double TenToTwenty { get; set; }
        [JsonProperty(PropertyName = "0-10")]
        public double ZeroToTen { get; set; }
    }

    public class DamageTakenPerMinDeltas
    {
        [JsonProperty(PropertyName = "10-20")]
        public double TenToTwenty { get; set; }
        [JsonProperty(PropertyName = "0-10")]
        public double ZeroToTen { get; set; }
    }

    public class DamageTakenDiffPerMinDeltas
    {
        [JsonProperty(PropertyName = "10-20")]
        public double TenToTwenty { get; set; }
        [JsonProperty(PropertyName = "0-10")]
        public double ZeroToTen { get; set; }
    }

    public class Timeline
    {
        public Timeline()
        {
            csDiffPerMinDeltas = new CsDiffPerMinDeltas();
            xpDiffPerMinDeltas = new XpDiffPerMinDeltas();
            damageTakenDiffPerMinDeltas = new DamageTakenDiffPerMinDeltas();
            csDiffPerMinDeltas = new CsDiffPerMinDeltas();
            creepsPerMinDeltas = new CreepsPerMinDeltas();
            xpPerMinDeltas = new XpPerMinDeltas();
            goldPerMinDeltas = new GoldPerMinDeltas();
            damageTakenPerMinDeltas = new DamageTakenPerMinDeltas();
        }

        public int ID { get; set; }
        public int participantId { get; set; }
        public CreepsPerMinDeltas creepsPerMinDeltas { get; set; }
        public XpPerMinDeltas xpPerMinDeltas { get; set; }
        public GoldPerMinDeltas goldPerMinDeltas { get; set; }
        public CsDiffPerMinDeltas csDiffPerMinDeltas { get; set; }
        public XpDiffPerMinDeltas xpDiffPerMinDeltas { get; set; }
        public DamageTakenPerMinDeltas damageTakenPerMinDeltas { get; set; }
        public DamageTakenDiffPerMinDeltas damageTakenDiffPerMinDeltas { get; set; }
        public string role { get; set; }
        public string lane { get; set; }
    }

    public class Participant
    {
        public int ID { get; set; }
        public int participantId { get; set; }
        public int teamId { get; set; }
        public int championId { get; set; }
        public int spell1Id { get; set; }
        public int spell2Id { get; set; }
        public List<Mastery> masteries { get; set; }
        public List<Rune> runes { get; set; }
        public string highestAchievedSeasonTier { get; set; }
        public Stats stats { get; set; }
        public Timeline timeline { get; set; }
    }

    public class Player
    {
        public string platformId { get; set; }
        public int accountId { get; set; }
        public string summonerName { get; set; }
        public int summonerId { get; set; }
        public string currentPlatformId { get; set; }
        public int currentAccountId { get; set; }
        public string matchHistoryUri { get; set; }
        public int profileIcon { get; set; }
    }

    public class ParticipantIdentity
    {
        public int ID { get; set; }
        public int participantId { get; set; }
        public Player player { get; set; }
    }

    public class Match
    {
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public long gameId { get; set; }
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public string platformId { get; set; }
        public long gameCreation { get; set; }
        public int gameDuration { get; set; }
        public int queueId { get; set; }
        public int mapId { get; set; }
        public int seasonId { get; set; }
        public string gameVersion { get; set; }
        public string gameMode { get; set; }
        public string gameType { get; set; }
        public List<Team> teams { get; set; }
        public List<Participant> participants { get; set; }
        public List<ParticipantIdentity> participantIdentities { get; set; }
    }
}
