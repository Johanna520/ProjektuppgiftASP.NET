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
    
    public class JoinEventModel : PageModel
    {
        private readonly EventContext _context;
        private readonly UserManager<MyUser> _userManager;

        public JoinEventModel(EventContext context,
            UserManager<MyUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        public Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Event.FirstOrDefaultAsync(m => m.Id == id);

            if (Event == null)
            {
                return NotFound();
            }


            return Page();
        }

        [BindProperty]
        public Event newEvents { get; set; }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userId = _userManager.GetUserId(User);
            var user = await _context.MyUser.Where(a => a.Id == userId)
             .Include(e => e.JoinedEvents)
             .FirstOrDefaultAsync();

            Event = await _context.Event.FirstOrDefaultAsync(m => m.Id == id);
            user.JoinedEvents.Add(Event);

            await _context.SaveChangesAsync();
            TempData["Success"] = "The Event has been added to your eventlist. See you there!!";
            return RedirectToPage("/MyEvents");
          


        }
    }
}
