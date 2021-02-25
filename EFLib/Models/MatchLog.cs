using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFLib.Models
{
    [Table("MatchLog")]
    public class MatchLog
    {
        [Key] public int Id { get; set; }
        
        public String Description { get; set; }
        
        [ForeignKey("ActionInMatch")] public int IdAction { get; set; }
        public ActionInMatch ActionInMatch { get; set; }
        
        [ForeignKey("Match")] public int IMatch { get; set; }
        public Match Match { get; set; }
        
        [ForeignKey("Player")]
        public int IdPlayer { get; set; }
        public Player Player { get; set; }
        
    }
}