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
using Microsoft.AspNetCore.Authorization;

namespace ProjektuppgiftASP.NET.Pages
{
    [AllowAnonymous]
    public class IndexModel : PageModel
    {
       

     

        public void OnGet()
        {
        }
    }
}
