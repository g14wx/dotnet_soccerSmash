using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFLib.Models
{
    [Table("Player")]
    public class Player
    {
        [Key] public int Id { get; set; }
        public String Name{ get; set; }
        public int NShirt{ get; set; }
        [ForeignKey("Team")]
        public int IdTeam { get; set; }
        public Team Team { get; set; }
        [ForeignKey("Position")]
        public int IdPosition { get; set; }
        public Position Position { get; set; }
    }
}