using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectMeridian.Data;
using ProiectMeridian.Models;

namespace ProiectMeridian.Pages.Clients
{
    public class IndexModel : PageModel
    {
        private readonly ProiectMeridian.Data.ProiectMeridianContext _context;

        public IndexModel(ProiectMeridian.Data.ProiectMeridianContext context)
        {
            _context = context;
        }

        public IList<Client> Client { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Client != null)
            {
                Client = await _context.Client.ToListAsync();
            }
        }
    }
}
