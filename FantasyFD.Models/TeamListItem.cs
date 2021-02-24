using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFD.Models
{
    public class TeamListItem
    {
        public Guid UserId { get; set; }
        public int TeamId { get; set; }
        public string TeamName { get; set; }

    }
}
