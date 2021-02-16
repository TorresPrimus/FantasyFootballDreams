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
        public int HomeScore { get; set; }
        [Required]
        public int AwayScore { get; set; }
        [Required]
        public int HomeTeamId { get; set; }
        [Required]
        public int AwayTeamId { get; set; }
    }
}
