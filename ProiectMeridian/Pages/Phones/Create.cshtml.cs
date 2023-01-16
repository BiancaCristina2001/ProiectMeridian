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
using ProiectMeridian.Data;
using ProiectMeridian.Models;

namespace ProiectMeridian.Pages.Phones
{

    public class CreateModel : TelefonCategoriesPageModel
    {
       
        private readonly ProiectMeridian.Data.ProiectMeridianContext _context;

        public CreateModel(ProiectMeridian.Data.ProiectMeridianContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {

            ViewData["ProducatorID"] = new SelectList(_context.Set<Producator>(), "ID",
           "Producatori");
            ViewData["DistribuitorID"] = new SelectList(_context.Set<Distribuitor>(), "ID",
           "Distribuitori");

            var telefon = new Telefon();
            telefon.TelefonCategories = new List<TelefonCategory>();
            PopulateAssignedCategoryData(_context, telefon);
            return Page();
        }

        [BindProperty]
        public Telefon Telefon { get; set; }


        public async Task<IActionResult> OnPostAsync(string[] selectedCategories)
        {
            var newTelefon = new Telefon();
            if (selectedCategories != null)
            {
                newTelefon.TelefonCategories = new List<TelefonCategory>();
                foreach (var cat in selectedCategories)
                {
                    var catToAdd = new TelefonCategory
                    {
                        CategoryID = int.Parse(cat)
                    };
                    newTelefon.TelefonCategories.Add(catToAdd);
                }
            }
            if (await TryUpdateModelAsync<Telefon>(
            newTelefon,
            "Telefon",
            i => i.Nume, i => i.Culoare,
            i => i.Price, i => i.ProducatorID, i => i.DistribuitorID))
            {
                _context.Telefon.Add(newTelefon);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Index.");
            }
            PopulateAssignedCategoryData(_context, newTelefon);
            return Page();
        }

    }
}
