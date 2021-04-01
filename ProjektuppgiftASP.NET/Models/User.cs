using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace ProjektuppgiftASP.NET.Models
{
    public class User : IdentityUser
    {
       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Event HostedEvents { get; set; } // one-to-many
        public List<Event> JoinedEvents { get; set; } // FK many-to-many

    }
}
