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
    public class IndexModel : PageModel
    {
        private readonly ProiectMeridian.Data.ProiectMeridianContext _context;

        public IndexModel(ProiectMeridian.Data.ProiectMeridianContext context)
        {
            _context = context;
        }

        public IList<Telefon> Telefon { get; set; } = default!;

        public TelefonData TelefonD { get; set; }
        public int TelefonID { get; set; }
        public int CategoryID { get; set; }
        public string NumeSort { get; set; }
        public string CurrentFilter { get; set; }


        public async Task OnGetAsync(int? id, int? categoryID, string sortOrder, string searchString)
        {
            TelefonD = new TelefonData();
            NumeSort = String.IsNullOrEmpty(sortOrder) ? "nume_desc" : "";
            CurrentFilter = searchString;



            TelefonD.Phones = await _context.Telefon
            .Include(b => b.Producator)
            .Include(b => b.Distribuitor)
            .Include(b => b.TelefonCategories)
            .ThenInclude(b => b.Category)
            .AsNoTracking()
            .OrderBy(b => b.Nume)
            .ToListAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                TelefonD.Phones = TelefonD.Phones.Where(s => s.Nume.Contains(searchString));
            }

                if (id != null)
                {
                    TelefonID = id.Value;
                    Telefon telefon = TelefonD.Phones
                    .Where(i => i.ID == id.Value).Single();
                    TelefonD.Categories = telefon.TelefonCategories.Select(s => s.Category);
                }
                switch (sortOrder)
                {
                    case "title_desc":
                        TelefonD.Phones = TelefonD.Phones.OrderByDescending(s =>
                       s.Nume);
                        break;

                }
            }
        }
    }

