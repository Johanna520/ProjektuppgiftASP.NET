using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ProjektuppgiftASP.NET.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ProjektuppgiftASP.NET.Data
{ 
    public class EventContext : IdentityDbContext<MyUser>
    {
        public EventContext(DbContextOptions<EventContext> options)
            : base(options)
        {
        }
        public DbSet<Event> Event { get; set; }
        public DbSet<MyUser> MyUser { get; set; }
        public async Task SeedAsync(UserManager<MyUser> userManager)
        {
            await Database.EnsureDeletedAsync();
            await Database.EnsureCreatedAsync();

            Event[] Event = new Event[]
            {
                new Event() { Title="Alicia Keys", Description="Music", Place="Ericsson Globe", Adress="Stockholm", Date=DateTime.Now,  SpotsAvailable=150,  },
                 new Event() { Title="CS:Go Major", Description="E-sport", Place="Ericsson Globe", Adress="Stockholm", Date=DateTime.Now,  SpotsAvailable=100,  },
                  new Event() { Title="Sweden International Horse Show", Description="Horse show", Place="Ericsson Globe", Adress="Stockholm", Date=DateTime.Now,  SpotsAvailable=330,  },
                   new Event() { Title="GAIS - Öster IF", Description="Soccer", Place="Ullevi", Adress="Gothenburg",Date=DateTime.Now,  SpotsAvailable=270, },
                    new Event() { Title="Iron Maiden", Description="Music", Place="Ullevi", Adress="Gothenburg", Date=DateTime.Now,  SpotsAvailable=500, }
            };



            await AddRangeAsync(Event);

            await SaveChangesAsync();
        }
    }
   
}
/*   Event model
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
 */