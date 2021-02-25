using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFLib.Models
{
    [Table("Match")]
    public class Match
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("TypeMatch")]
        public int IdTypeMatch { get; set; }
        public TypeMatch TypeMatch { get; set; }
        public virtual List<TeamHasMatches> TeamHasMatchesList { get; set; }
        public virtual List<MatchLog> MatchLogs { get; set; }
    }
}