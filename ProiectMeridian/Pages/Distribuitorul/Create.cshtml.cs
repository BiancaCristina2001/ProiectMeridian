﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProiectMeridian.Data;
using ProiectMeridian.Models;

namespace ProiectMeridian.Pages.Distribuitorul
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
            return Page();
        }

        [BindProperty]
        public Distribuitor Distribuitor { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Distribuitor.Add(Distribuitor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
