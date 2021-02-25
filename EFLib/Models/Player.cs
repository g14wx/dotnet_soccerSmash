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
        public virtual List<TeamHasMatches> TeamHasMatchesList { get; set; }
    }
}