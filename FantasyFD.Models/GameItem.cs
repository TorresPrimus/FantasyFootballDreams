using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFD.Models
{
    public class GameItem
    {
        public int Id { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        [Display(Name = "Game Time")]
        public DateTime DateOfGame { get; set; }
    }
}
