using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFLib.Models
{
    [Table("University")]
    public class University
    {
        [Key]
        public int Id { get; set; }
        public String Title { get; set; }
        public List<Player> Players { get; set; }
    }
}