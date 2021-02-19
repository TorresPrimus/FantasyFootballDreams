using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFD.Models
{
    public class TeamEdit
    {
        public Guid UserId { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }
    }
}
