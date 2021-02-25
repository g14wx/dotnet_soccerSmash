using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFLib.Models
{
    [Table("TeamHasMatches")]
    public class TeamHasMatches
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Match")]
        public int IdMatch { get; set; }
        public Match Match { get; set; }
        [ForeignKey("Team")]
        public int IdTeam { get; set; }
        public Team Team { get; set; }
    }
}