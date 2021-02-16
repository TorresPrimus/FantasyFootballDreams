using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFD.Models.Player
{
    public class ListPlayer
    {
        [DisplayName("Player Id")]
        public int PlayerId { get; set; }
        [DisplayName("Team Id")]
        public int TeamID { get; set; }
        [DisplayName("Team Name")]
        public string TeamName { get; set; }
        [DisplayName("First Name")]
        public string PlayerFirstName { get; set; }
        [DisplayName("Last Name")]
        public string PlayerLastName { get; set; }
    }
}
