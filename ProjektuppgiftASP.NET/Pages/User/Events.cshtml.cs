using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjektuppgiftASP.NET.Data;
using ProjektuppgiftASP.NET.Models;

namespace ProjektuppgiftASP.NET.Pages
{
    [Authorize]
    public class EventsModel : PageModel
    {
        
        private readonly EventContext _context;

        public EventsModel(EventContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get;set; }

        public async Task OnGetAsync()
        {
            Event = await _context.Event.ToListAsync();
        }
    }
}
