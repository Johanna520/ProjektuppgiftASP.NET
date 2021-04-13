using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProjektuppgiftASP.NET.Data;
using ProjektuppgiftASP.NET.Models;

namespace ProjektuppgiftASP.NET.Pages
{
    public class AdminPageModel : PageModel
    {
        private readonly UserManager<MyUser> _userManager;
        private readonly EventContext _context;
        public AdminPageModel(
            UserManager<MyUser> userManager,
            EventContext context
            )
        {
            _userManager = userManager;
            _context = context;
        }

        public List<MyUser> Users;
        public async Task OnGet() { 
            var users = await _userManager.Users.ToListAsync();

        Users = users;
        }

        [BindProperty]
        public bool CheckBox { get; set; }
        public async Task OnPost(string? id)
        {
            if (!CheckBox)
                await _userManager.RemoveFromRoleAsync(await _userManager.FindByIdAsync(id), "Organizer");
            else
                await _userManager.AddToRoleAsync(await _userManager.FindByIdAsync(id), "Organizer");

            await OnGet();
        }
    }
}