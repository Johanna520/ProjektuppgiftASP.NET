using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ProjektuppgiftASP.NET.Data;
using ProjektuppgiftASP.NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace ProjektuppgiftASP.NET.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly EventContext _context;
        private readonly UserManager<MyUser> _userManager;


        public IndexModel(ILogger<IndexModel> logger, 
            EventContext context, 
            UserManager<MyUser> userManager)
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
        }

       public async Task OnGetAsync()
        {
            await _context.SeedAsync(_userManager);
        }
    }
}
