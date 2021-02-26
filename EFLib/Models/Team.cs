using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace EFLib.Models
{
    [Table("Team")]
    public class Team
    {
        [Key] public int Id { get; set; }
        public String Title{ get; set; }
        public String Img { get; set; }
        public virtual List<LeagueHasTeams> LeagueHasTeamsList { get; set; } = new List<LeagueHasTeams>();
        public virtual List<TeamHasMatches> TeamHasMatchesList { get; set; }
        public virtual List<Player> Players { get; set; }
        
        [NotMapped]
        public List<int> SelectedLeagues { get; set; }
        
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        
    }
}