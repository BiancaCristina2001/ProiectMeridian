using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectMeridian.Data;
using ProiectMeridian.Models;

namespace ProiectMeridian.Pages.Phones
{
    public class DetailsModel : PageModel
    {
        private readonly ProiectMeridian.Data.ProiectMeridianContext _context;

        public DetailsModel(ProiectMeridian.Data.ProiectMeridianContext context)
        {
            _context = context;
        }

      public Telefon Telefon { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Telefon == null)
            {
                return NotFound();
            }

            var telefon = await _context.Telefon.FirstOrDefaultAsync(m => m.ID == id);
            if (telefon == null)
            {
                return NotFound();
            }
            else 
            {
                Telefon = telefon;
            }
            return Page();
        }
    }
}
