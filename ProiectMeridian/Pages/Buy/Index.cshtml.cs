using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectMeridian.Data;
using ProiectMeridian.Models;

namespace ProiectMeridian.Pages.Buy
{
    public class IndexModel : PageModel
    {
        private readonly ProiectMeridian.Data.ProiectMeridianContext _context;

        public IndexModel(ProiectMeridian.Data.ProiectMeridianContext context)
        {
            _context = context;
        }

        public IList<Buying> Buying { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Buying != null)
            {
                Buying = await _context.Buying
                .Include(b => b.Telefon)
                .ThenInclude(b => b.Producator)
                .Include(b=>b.Client)
                .ToListAsync();
            }
        }
    }
}
