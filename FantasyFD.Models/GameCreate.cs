using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFD.Models
{
    public class GameCreate
    {

        [Key]
        public int Id { get; set; }
        [Required]
        public double HomeScore { get; set; }
        [Required]
        public double AwayScore { get; set; }
        [Required]
        public int HomeTeamId { get; set; }
        [Required]
        public int AwayTeamId { get; set; }
        public DateTime DateOfGame { get; set; }
    }
}
