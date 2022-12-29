﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using lab12.Models;

namespace lab12.Pages.Regions
{
    public class CreateModel : PageModel
    {
        private readonly lab12.Models.InternetProviderContext _context;

        public CreateModel(lab12.Models.InternetProviderContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Region Region { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Region.Add(Region);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
