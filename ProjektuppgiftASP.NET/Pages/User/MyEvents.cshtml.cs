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

namespace ProjektuppgiftASP.NET.Pages
{
    [Authorize]
    public class MyEventsModel : PageModel
    {
        private readonly EventContext _context;
        private readonly UserManager<MyUser> _userManager;

        public MyEventsModel(EventContext context, 
            UserManager<MyUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Event> Event { get;set; }

        public async Task OnGetAsync()
        {
            var userId = _userManager.GetUserId(User);

            var user = await _context.Users
                .Where(u => u.Id == userId)
                .Include(u => u.JoinedEvents)
                .FirstOrDefaultAsync();

            Event = user.JoinedEvents;

         
        }

  
    }
}
