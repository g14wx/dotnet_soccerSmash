using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFLib.Models
{
    [Table("Season")]
    public class Season
    {
        [Key]
        public int id { get; set; }
        public bool isActive { get; set; } 
        [ForeignKey("League")]
        public int LeagueId { get; set; }
        public League League { get; set; }
        [ForeignKey("LeagueHasTeams")]
        public int IdWinnerTeamLeagueSeason { get; set; }
        public virtual LeagueHasTeams LeagueHasTeams { get; set; }
        
        public virtual List<Match> Matches { get; set; }
    }
}