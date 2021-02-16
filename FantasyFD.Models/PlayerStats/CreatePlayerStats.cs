using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFD.Models.PlayerStats
{
    public class CreatePlayerStats
    {
        [DisplayName("Player Stats Id")]
        public int PlayerStatsId { get; set; }
        [Required, DisplayName("Player Id")]
        public int PlayerId { get; set; }
        [Required, DisplayName("Passing Yards")]
        public int PassingYards { get; set; }
        [Required, DisplayName("Passing Touchdowns")]
        public int PassingTouchdowns { get; set; }
        [Required, DisplayName("Interceptions Thrown")]
        public int InterceptionThrown { get; set; }
        [Required, DisplayName("Rushing Yards")]
        public int RushingYards { get; set; }
        [Required, DisplayName("Rushing Attempts")]
        public int RushingAttempts { get; set; }
        [Required, DisplayName("Rushing Touchdowns")]
        public int RushingTouchDowns { get; set; }
        [Required, DisplayName("Receiving Yards")]
        public int ReceivingYards { get; set; }
        [Required]
        public int Catches { get; set; }
        [Required, DisplayName("Receiving Touchdowns")]
        public int ReceivingTouchDowns { get; set; }
        [Required]
        public int Fumbles { get; set; }
        [Required]
        public int Tackles { get; set; }
        [Required]
        public double Sacks { get; set; }
        [Required]
        public int Interceptions { get; set; }
        [Required, DisplayName("Forced Fumbles")]
        public int ForcedFumbles { get; set; }
        [Required, DisplayName("Fumble Recovery")]
        public int FumbleRecovery { get; set; }
        [Required]
        public int Safety { get; set; }
        [Required, DisplayName("Blocked Kicks")]
        public int BlockedKick { get; set; }
        [Required, DisplayName("Return Touchdowns")]
        public int ReturnTouchDown { get; set; }
    }
}
