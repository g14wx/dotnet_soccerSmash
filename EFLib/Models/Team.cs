using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace EFLib.Models
{
    
    [JsonObject(IsReference = true)] 
    [Table("Team")]
    public class Team
    {
        [Key] public int Id { get; set; }
        public String Title{ get; set; }
        public String Img { get; set; }
        
        [JsonIgnore] 
        [IgnoreDataMember] 
        public virtual List<LeagueHasTeams> LeagueHasTeamsList { get; set; } = new List<LeagueHasTeams>();
        
        [JsonIgnore] 
        [IgnoreDataMember] 
        public virtual List<TeamHasMatches> TeamHasMatchesList { get; set; }
        
        [JsonIgnore] 
        [IgnoreDataMember] 
        public virtual List<Player> Players { get; set; }
        
        [NotMapped]
        public List<int> SelectedLeagues { get; set; }
        
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        
    }
}