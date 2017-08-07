using System.ComponentModel.DataAnnotations.Schema;

namespace LolApi
{
    public class Champion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Key { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }
    }
}
