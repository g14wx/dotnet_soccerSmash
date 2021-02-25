using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFLib.Models
{
    [Table("LeagueHasTeams")]
    public class LeagueHasTeams
    {
        [Key]
        public int id { get; set; }

        [ForeignKey("leage")]
        public int LeagueId { get; set; }
        public League League { get; set; }
        
        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public Team Team { get; set; }

        public bool isActive { get; set; }
    }
}