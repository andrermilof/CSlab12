using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab12.Models;

namespace lab12.Pages.Tariffs
{
    public class IndexModel : PageModel
    {
        private readonly lab12.Models.InternetProviderContext _context;

        public IndexModel(lab12.Models.InternetProviderContext context)
        {
            _context = context;
        }

        public IList<Tariff> Tariff { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Tariff != null)
            {
                Tariff = await _context.Tariff.ToListAsync();
            }
        }
    }
}
