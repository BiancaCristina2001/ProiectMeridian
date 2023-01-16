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
    public class DeleteModel : PageModel
    {
        private readonly ProiectMeridian.Data.ProiectMeridianContext _context;

        public DeleteModel(ProiectMeridian.Data.ProiectMeridianContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Buying == null)
            {
                return NotFound();
            }
            var buying = await _context.Buying.FindAsync(id);

            if (buying != null)
            {
                Buying = buying;
                _context.Buying.Remove(Buying);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
