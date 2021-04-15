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

namespace ProjektuppgiftASP.NET.Pages.Admin
{
    [Authorize(Roles = "Admin")]
    public class UserManagerModel : PageModel
    {
        private readonly EventContext _context;
        public readonly UserManager<MyUser> _userManager;

        public UserManagerModel(EventContext context, UserManager<MyUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public List<MyUser> MyUsers { get; set; }




        public async Task OnGetAsync(string id)
        {


            MyUsers = await _context.MyUser.ToListAsync();
            await _context.SaveChangesAsync();
        }


        public async Task<IActionResult> OnPostAsync(string id)
        {

            var user = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);

            var isOrganizer = await _userManager.IsInRoleAsync(user, "Organizer");

            if (await _userManager.IsInRoleAsync(user, "Organizer"))
            {
                //await _userManager.AddToRoleAsync(user, "organizer");
                await _userManager.RemoveFromRoleAsync(user, "Organizer");
            }
            else
            {
                //await _userManager.RemoveFromRoleAsync(user, "organizer");
                await _userManager.AddToRoleAsync(user, "Organizer");
            }


            await _context.SaveChangesAsync();
            return RedirectToPage("/Admin/ManageUsers");
        }
    }
     
    }
    



/*
 *    [BindProperty]
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
            return RedirectToPage("/User/MyEvents");
          


        }
 * 
 * */