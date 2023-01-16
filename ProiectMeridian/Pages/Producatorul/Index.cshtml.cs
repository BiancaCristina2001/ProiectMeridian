using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ProiectMeridian.Data;
using ProiectMeridian.Models;
using ProiectMeridian.Models.ViewModels;

namespace ProiectMeridian.Pages.Producatorul
{
    public class IndexModel : PageModel
    {
        private readonly ProiectMeridian.Data.ProiectMeridianContext _context;

        public IndexModel(ProiectMeridian.Data.ProiectMeridianContext context)
        {
            _context = context;
        }

        public IList<Producator> Producator { get; set; } = default!;

        public ProducatorIndexData ProducatorData { get; set; }
        public int ProducatorID { get; set; }
        public int TelefonID { get; set; }
        public async Task OnGetAsync(int? id, int? telefonID)
        {
            ProducatorData = new ProducatorIndexData();
            ProducatorData.Producatorul = await _context.Producator
            .Include(i => i.Phones)
            .ThenInclude(c => c.Distribuitor)
            .OrderBy(i => i.Producatori)
            .ToListAsync();
            if (id != null)
            {
                ProducatorID = id.Value;
                Producator producator = ProducatorData.Producatorul
                .Where(i => i.ID == id.Value).Single();
                ProducatorData.Phones = producator.Phones;
            }

        }
    }
}