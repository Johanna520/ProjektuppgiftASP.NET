using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjektuppgiftASP.NET.Data;
using ProjektuppgiftASP.NET.Models;

namespace ProjektuppgiftASP.NET.Pages.Organizer
{
    public class AddEventModel : PageModel
    {
        private readonly EventContext _context;

        public AddEventModel(EventContext context)
        {
            _context = context;
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
                _context.Add(Event);
                await _context.SaveChangesAsync();
                TempData["Success"] = "The Event has been added!";                                
               return RedirectToPage("/Organizer/OrganizeEvents");
            }

     
            
            return RedirectToPage("Index");
        }
    }
}

/*
 * Organizer ska skapa och lägga till nytt event
 * 
 * nytt event måste vara inblandat
 * referns till 
 */
