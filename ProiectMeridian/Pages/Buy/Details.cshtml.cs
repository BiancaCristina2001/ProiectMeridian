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
    public class DetailsModel : PageModel
    {
        private readonly ProiectMeridian.Data.ProiectMeridianContext _context;

        public DetailsModel(ProiectMeridian.Data.ProiectMeridianContext context)
        {
            _context = context;
        }

      public Buying Buying { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Buying == null)
            {
                return NotFound();
            }

            var buying = await _context.Buying.FirstOrDefaultAsync(m => m.ID == id);
            if (buying == null)
            {
                return NotFound();
            }
            else 
            {
                Buying = buying;
            }
            return Page();
        }
    }
}
