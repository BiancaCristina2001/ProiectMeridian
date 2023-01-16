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
    public class CreateModel : PageModel
    {
        private readonly ProiectMeridian.Data.ProiectMeridianContext _context;

        public CreateModel(ProiectMeridian.Data.ProiectMeridianContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var telefonList = _context.Telefon
 
                .Include(b => b.Producator)
 
                .Select(x => new
 
                {
    
                    x.ID,
     
                    TelefonFullName = x.Nume + " - " + x.Producator.FullName });

            ViewData["TelefonID"] = new SelectList(telefonList, "ID", "TelefonFullName");
            ViewData["ClientID"] = new SelectList(_context.Client, "ID","FullName");

            return Page();
        }

        [BindProperty]
        public Buying Buying { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Buying.Add(Buying);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
