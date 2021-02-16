using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFD.Models
{
    public class TeamDetail
    {
        public int TeamId { get; set; }

        public string TeamName { get; set; }

        [Display(Name = "Created")]
        public DateTimeOffset CreatedUtc { get; set; }
        [Display(Name = "Modified")]
        public DateTimeOffset ModifiedUtc { get; set; }

        public virtual ICollection<Players> ListOfPlayers { get; set; }
        public virtual ICollection<Games> ListOfGames { get; set; }
    }


    // NEEDS TO BE DELETED PRIOR TO INITIAL MERGE WITH GROUP
    public class Players { } // NEEDS TO BE DELETED PRIOR TO INITIAL MERGE WITH GROUP
    public class Games { } // NEEDS TO BE DELETED PRIOR TO INITIAL MERGE WITH GROUP
}
