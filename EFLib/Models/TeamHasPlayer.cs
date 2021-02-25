using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFLib.Models
{
    [Table("TeamHasPlayer")]
    public class TeamHasPlayer
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Team")]
        public int IdTeam { get; set; }
        public Team Team { get; set; }
        [ForeignKey("Player")]
        public int IdPlayer {get; set; }

        public Player Player { get; set; }
    }
}