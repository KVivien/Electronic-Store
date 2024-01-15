using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Electronic_Store.Data;
using Electronic_Store.Models;

namespace Electronic_Store.Pages.Vendors
{
    public class EditModel : PageModel
    {
        private readonly Electronic_Store.Data.Electronic_StoreContext _context;

        public EditModel(Electronic_Store.Data.Electronic_StoreContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vendor Vendor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Vendor == null)
            {
                return NotFound();
            }

            var vendor =  await _context.Vendor.FirstOrDefaultAsync(m => m.ID == id);
            if (vendor == null)
            {
                return NotFound();
            }
            Vendor = vendor;
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

            _context.Attach(Vendor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VendorExists(Vendor.ID))
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

        private bool VendorExists(int id)
        {
          return (_context.Vendor?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
