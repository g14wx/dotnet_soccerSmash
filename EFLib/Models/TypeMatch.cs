using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EFLib.Models
{
    public class TypeMatch
    {
        [Key]
        public int Id { get; set; }
        public String Type { get; set; }
        public List<Match> Matches { get; set; }
    }
}