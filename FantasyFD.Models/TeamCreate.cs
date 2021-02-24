using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyFD.Models
{
    public class TeamCreate
    {
        [Required, MinLength(2, ErrorMessage = "Please enter at least 2 characters."), MaxLength(50, ErrorMessage = "50 character limit has been breached.")]
        public string TeamName { get; set; }
    }
}
