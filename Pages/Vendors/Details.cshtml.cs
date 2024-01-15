﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Electronic_Store.Data;
using Electronic_Store.Models;

namespace Electronic_Store.Pages.Vendors
{
    public class DetailsModel : PageModel
    {
        private readonly Electronic_Store.Data.Electronic_StoreContext _context;

        public DetailsModel(Electronic_Store.Data.Electronic_StoreContext context)
        {
            _context = context;
        }

      public Vendor Vendor { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Vendor == null)
            {
                return NotFound();
            }

            var vendor = await _context.Vendor.FirstOrDefaultAsync(m => m.ID == id);
            if (vendor == null)
            {
                return NotFound();
            }
            else 
            {
                Vendor = vendor;
            }
            return Page();
        }
    }
}