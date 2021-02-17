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

        public int HomeTeamId { get; set; }

        public int TeamId { get; set; }


        [Required]
        public double HomeScore { get; set; }

        [Required]

        public int AwayTeamId { get; set; }

        [Required]
        public double AwayScore { get; set; }

        [Required]
        public DateTime DateOfGame { get; set; }

        public virtual ICollection<Team> ListOfTeams { get; set; }

            public Games()
            {
                ListOfTeams = new HashSet<Team>();
            }
    }
}
