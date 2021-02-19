using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFD.Data
{//wack
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }

        [Required]
        public string PlayerFirstName { get; set; }
        [Required]
        public string PlayerLastName { get; set; }
        [Required]
        public string PlayerPosition { get; set; }
        [Required]
        public int PlayerJerseyNumber { get; set; }
        [Required]
        public double PlayerHeightByInches { get; set; }
        [Required]
        public double PlayerWeightByPounds { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        public virtual ICollection<PlayerStats> PlayerStats { get; set; }
    }
}