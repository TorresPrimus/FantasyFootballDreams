using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFD.Data
{
    public class Games
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Team))]
        public int TeamId { get; set; }

        [Required]
        public double Score { get; set; }

        [Required]
        [ForeignKey(nameof(Team))]
        public int AwayTeamId { get; set; }

        [Required]
        public double AwayScore { get; set; }

        [Required]
        public DateTime DateOfGame { get; set; }

        public virtual Games Game { get; set; }

        public virtual ICollection<Team> ListOfTeams { get; set; }

        public Games()
        {
            ListOfTeams = new HashSet<Team>();
        }
    }
}
