using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFLib.Models
{
    [Table("ActionInMatch")]
    public class ActionInMatch
    {
        [Key]
        public int Id { get; set; }
        public String Action { get; set; }
        public virtual List<MatchLog> MatchLogs { get; set; }
    }
}