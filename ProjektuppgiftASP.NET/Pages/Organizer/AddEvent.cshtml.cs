using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjektuppgiftASP.NET.Data;
using ProjektuppgiftASP.NET.Models;

namespace ProjektuppgiftASP.NET.Pages.Organizer
{
    [Authorize(Roles = "Organizer")]
    public class AddEventModel : PageModel
    {
        private readonly EventContext _context;
        private readonly UserManager<MyUser> _userManager;
        public AddEventModel(EventContext context,
            UserManager<MyUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Event Event { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
              var user = await _userManager.GetUserAsync(User);
                Event.Organizer = user;
                _context.Add(Event);
                await _context.SaveChangesAsync();
                TempData["Success"] = "The Event has been added!";                                
               return RedirectToPage("/Organizer/OrganizeEvents");
            }
            
                return Page();
            
          


     


        }
    }
}

/*
 * Organizer ska skapa och lägga till nytt event
 * 
 * nytt event måste vara inblandat
 * referns till 
 */
