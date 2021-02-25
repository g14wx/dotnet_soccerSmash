using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFLib.Models
{
    [Table("Team")]
    public class Team
    {
        [Key] public int Id { get; set; }
        public String Title{ get; set; }
        public String Img { get; set; }
        public virtual List<LeagueHasTeams> LeagueHasTeamsList { get; set; } = new List<LeagueHasTeams>();
        public virtual Season Season { get; set; }
        public virtual List<TeamHasMatches> TeamHasMatchesList { get; set; }
        public virtual List<TeamHasPlayer> TeamHasPlayers { get; set; }
    }
}