using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectMeridian.Data;
using ProiectMeridian.Models;

namespace ProiectMeridian.Pages.Distribuitorul
{
    public class DeleteModel : PageModel
    {
        private readonly ProiectMeridian.Data.ProiectMeridianContext _context;

        public DeleteModel(ProiectMeridian.Data.ProiectMeridianContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Distribuitor Distribuitor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Distribuitor == null)
            {
                return NotFound();
            }

            var distribuitor = await _context.Distribuitor.FirstOrDefaultAsync(m => m.ID == id);

            if (distribuitor == null)
            {
                return NotFound();
            }
            else 
            {
                Distribuitor = distribuitor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Distribuitor == null)
            {
                return NotFound();
            }
            var distribuitor = await _context.Distribuitor.FindAsync(id);

            if (distribuitor != null)
            {
                Distribuitor = distribuitor;
                _context.Distribuitor.Remove(Distribuitor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
