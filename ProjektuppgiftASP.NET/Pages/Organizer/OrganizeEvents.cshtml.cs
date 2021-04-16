using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjektuppgiftASP.NET.Data;
using ProjektuppgiftASP.NET.Models;

namespace ProjektuppgiftASP.NET.Pages.Organizer
{
    [Authorize(Roles = "Organizer")]
    public class OrganizeEventsModel : PageModel
    {
        private readonly EventContext _context;
        private readonly UserManager<MyUser> _userManager;

        public OrganizeEventsModel(EventContext context,
            UserManager<MyUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Event> Event { get;set; }

        public async Task OnGetAsync(int? id)
        {
            var user = User.Identity;

            var userModel = _context.Users.FirstOrDefault(m => m.UserName == user.Name);
            Event = await _context.Event.Where(m => m.Organizer == userModel).ToListAsync();

        }
    }
}
