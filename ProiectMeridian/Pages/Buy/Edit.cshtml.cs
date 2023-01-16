using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectMeridian.Data;
using ProiectMeridian.Models;

namespace ProiectMeridian.Pages.Buy
{
    public class EditModel : PageModel
    {
        private readonly ProiectMeridian.Data.ProiectMeridianContext _context;

        public EditModel(ProiectMeridian.Data.ProiectMeridianContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Buying Buying { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Buying == null)
            {
                return NotFound();
            }

            var buying =  await _context.Buying.FirstOrDefaultAsync(m => m.ID == id);
            if (buying == null)
            {
                return NotFound();
            }
            Buying = buying;
           ViewData["ClientID"] = new SelectList(_context.Client, "ID", "ID");
           ViewData["TelefonID"] = new SelectList(_context.Telefon, "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Buying).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BuyingExists(Buying.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BuyingExists(int id)
        {
          return _context.Buying.Any(e => e.ID == id);
        }
    }
}
