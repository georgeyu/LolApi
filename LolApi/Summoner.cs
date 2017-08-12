using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LolApi
{
    public class Summoner
    {
        public int profileIconId { get; set; }
        public string name { get; set; }
        public int summonerLevel { get; set; }
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int accountId { get; set; }
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int id { get; set; }
        public long revisionDate { get; set; }
    }
}
