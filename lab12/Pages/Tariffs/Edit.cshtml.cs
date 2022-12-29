using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using lab12.Models;

namespace lab12.Pages.Tariffs
{
    public class EditModel : PageModel
    {
        private readonly lab12.Models.InternetProviderContext _context;

        public EditModel(lab12.Models.InternetProviderContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tariff Tariff { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tariff == null)
            {
                return NotFound();
            }

            var tariff =  await _context.Tariff.FirstOrDefaultAsync(m => m.TariffId == id);
            if (tariff == null)
            {
                return NotFound();
            }
            Tariff = tariff;
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

            _context.Attach(Tariff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TariffExists(Tariff.TariffId))
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

        private bool TariffExists(int id)
        {
          return _context.Tariff.Any(e => e.TariffId == id);
        }
    }
}
