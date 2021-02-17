using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFD.Models
{
    public class GameEdit
    {
        public int Id { get; set; }
        public int HomeTeamId { get; set; }
        public double HomeScore { get; set; }
        public int AwayTeamId { get; set; }
        public double AwayScore { get; set; }
        public DateTime DateOfGame { get; set; }
    }
}
