using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFD.Data
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }

        [Required]
        public string TeamName { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }

        public virtual ICollection<Players> ListOfPlayers { get; set; }
        public virtual ICollection<Games> ListOfGames { get; set; }
        
        public Team()
        {
            ListOfPlayers = new HashSet<Players>();
            ListOfGames = new HashSet<Games>();
        }

    }


    // NEEDS TO BE DELETED PRIOR TO INITIAL MERGE WITH GROUP
    public class Players { } // NEEDS TO BE DELETED PRIOR TO INITIAL MERGE WITH GROUP
    public class Games { } // NEEDS TO BE DELETED PRIOR TO INITIAL MERGE WITH GROUP

}
