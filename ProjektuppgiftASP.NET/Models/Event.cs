using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjektuppgiftASP.NET.Models
{
    public class Event
    {
        public int Id { get; set; }

        [InverseProperty("JoinedEvents")]
        public List<User> Attendees { get; set; } //FK, many-to-many

        [InverseProperty("HostedEvents")]
        public List<User> Organizer { get; set; } // FK, one-to-many
        public string Title { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public string Adress { get; set; }
        public DateTime Date { get; set; }
        public int SpotsAvailable { get; set; }
    }
}
