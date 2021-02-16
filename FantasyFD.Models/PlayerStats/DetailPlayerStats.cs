using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFD.Models.PlayerStats
{
    public class DetailPlayerStats
    {
        [DisplayName("Player Stats Id")]
        public int PlayerStatsId { get; set; }
        [DisplayName("Player Id")]
        public int PlayerID { get; set; }
        [DisplayName("Name")]
        public string PlayerName { get; set; }
        [DisplayName("Passing Yards")]
        public int PassingYards { get; set; }
        [DisplayName("Passing Touchdowns")]
        public int PassingTouchdowns { get; set; }
        [DisplayName("Interceptions Thrown")]
        public int InterceptionThrown { get; set; }
        [DisplayName("Rushing Yards")]
        public int RushingYards { get; set; }
        [DisplayName("Rushing Attempts")]
        public int RushingAttempts { get; set; }
        [DisplayName("Rushing Touchdowns")]
        public int RushingTouchDowns { get; set; }
        [DisplayName("Receiving Yards")]
        public int ReceivingYards { get; set; }
        public int Catches { get; set; }
        [DisplayName("Receiving Touchdowns")]
        public int ReceivingTouchDowns { get; set; }
        public int Fumbles { get; set; }
        public int Tackles { get; set; }
        public double Sacks { get; set; }
        public int Interceptions { get; set; }
        [DisplayName("Forced Fumbles")]
        public int ForcedFumbles { get; set; }
        [DisplayName("Fumble Recovery")]
        public int FumbleRecovery { get; set; }
        public int Safety { get; set; }
        [DisplayName("Blocked Kicks")]
        public int BlockedKick { get; set; }
        [DisplayName("Return Touchdowns")]
        public int ReturnTouchDown { get; set; }
    }
}
