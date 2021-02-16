using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFD.Models.Player
{
    [NotMapped]
    public class CreatePlayer
    {
        //public int PlayerID { get; set; } //not needed in model. Gets generated in the database
        [Required, DisplayName("Team Id")]
        public int TeamId { get; set; }

        [Required, DisplayName("First Name")]
        public string PlayerFirstName { get; set; }
        [Required, DisplayName("Last Name")]
        public string PlayerLastName { get; set; }

        [MaxLength(2, ErrorMessage = "Please enter the abbriviation with consisting of only 2 characters. (QB, RB, WR, TE, OL, DL, LB, CB, FS, SS)"), DisplayName("Position")]
        //Stretch Goal -- Make Enum
        public string PlayerPosition { get; set; }

        [Required, DisplayName("Jersey Number")]
        [Range(0, 99, ErrorMessage = "Jersey number can only be 2 digits and has to be between 0 and 99.")]
        public int PlayerJerseyNumber { get; set; }

        [Required, DisplayName("Height")]
        public double PlayerHeightByInches { get; set; }
        [Required, DisplayName("Weight")]
        public double PlayerWeightByPounds { get; set; }
    }
}
