using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProiectMeridian.Data;
using ProiectMeridian.Models;

namespace ProiectMeridian.Pages.Phones
{
    public class EditModel : TelefonCategoriesPageModel
    {
        private readonly ProiectMeridian.Data.ProiectMeridianContext _context;

        public EditModel(ProiectMeridian.Data.ProiectMeridianContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Telefon Telefon { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }
            Telefon = await _context.Telefon
 .Include(b => b.Producator)
 .Include(b => b.Distribuitor)
 .Include(b => b.TelefonCategories).ThenInclude(b => b.Category)
 .AsNoTracking()
 .FirstOrDefaultAsync(m => m.ID == id);

            var telefon =  await _context.Telefon.FirstOrDefaultAsync(m => m.ID == id);
            if (telefon == null)
            {
                return NotFound();
            }
            PopulateAssignedCategoryData(_context, Telefon);
            ViewData["ProducatorID"] = new SelectList(_context.Set<Producator>(), "ID",
"Producatori");
            ViewData["DistribuitorID"] = new SelectList(_context.Set<Distribuitor>(), "ID",
            "Distribuitori");

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedCategories)
        {
            if (id == null)
            {
                return NotFound();
            }
            var telefonToUpdate = await _context.Telefon
            .Include(i => i.Producator)
            .Include(i => i.Distribuitor)
            .Include(i => i.TelefonCategories)
            .ThenInclude(i => i.Category)
            .FirstOrDefaultAsync(s => s.ID == id);
            if (telefonToUpdate == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync<Telefon>(
            telefonToUpdate,
            "Telefon",
            i => i.Nume, i => i.Culoare,
            i => i.Price, i => i.ProducatorID, i => i.DistribuitorID))
            {
                UpdateTelefonCategories(_context, selectedCategories, telefonToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Apelam UpdateBookCategories pentru a aplica informatiile din checkboxuri la entitatea Books care
            //este editata
            UpdateTelefonCategories(_context, selectedCategories, telefonToUpdate);
            PopulateAssignedCategoryData(_context, telefonToUpdate);
            return Page();
        }
    }
}