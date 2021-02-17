using FantasyFD.Models.Player;
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

        public virtual ICollection<ListPlayer> ListOfPlayers { get; set; }
        public virtual ICollection<GameItem> ListOfGames { get; set; }
    }

}
