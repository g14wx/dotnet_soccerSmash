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
    [Table("Player")]
    public class Player
    {
        [Key] public int Id { get; set; }
        public String Name{ get; set; }
        public int NShirt{ get; set; }
        public int Age { get; set; }
        public String Img { get; set; }
        public double Stature { get; set; }
        public double Weight { get; set; }
        [ForeignKey("University")]
        public int IdUniversity { get; set; }
        [ForeignKey("Team")]
        public int IdTeam { get; set; }
        [JsonIgnore] 
        [IgnoreDataMember] 
        public Team Team { get; set; }
        [ForeignKey("Position")]
        public int IdPosition { get; set; }
        public Position Position { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}