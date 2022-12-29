﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using lab12.Models;

namespace lab12.Pages.Tariffs
{
    public class DeleteModel : PageModel
    {
        private readonly lab12.Models.InternetProviderContext _context;

        public DeleteModel(lab12.Models.InternetProviderContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Tariff Tariff { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tariff == null)
            {
                return NotFound();
            }

            var tariff = await _context.Tariff.FirstOrDefaultAsync(m => m.TariffId == id);

            if (tariff == null)
            {
                return NotFound();
            }
            else 
            {
                Tariff = tariff;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Tariff == null)
            {
                return NotFound();
            }
            var tariff = await _context.Tariff.FindAsync(id);

            if (tariff != null)
            {
                Tariff = tariff;
                _context.Tariff.Remove(Tariff);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
