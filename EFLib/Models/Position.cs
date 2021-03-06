using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFLib.Models
{
     [Table("Position")]
    public class Position
    {
        [Key]
        public int Id { get; set; }
        public String position { get; set; }
        public List<Player> Players { get; set; }
    }
}