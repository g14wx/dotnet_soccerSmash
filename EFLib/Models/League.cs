using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFLib.Models
{
    [Table("League")]
    public class League
    {
        [Key]
        public int Id { get; set; }
        
        public String Title { get; set; }
        public List<LeagueHasTeams> LeagueHasTeamsList { get; set; } = new List<LeagueHasTeams>();
        public List<Season> Seasons { get; set; }
    }
}