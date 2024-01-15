using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Electronic_Store.Data;
using Electronic_Store.Models;
using System.Security.Policy;

namespace Electronic_Store.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly Electronic_Store.Data.Electronic_StoreContext _context;

        public CreateModel(Electronic_Store.Data.Electronic_StoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["VendorID"] = new SelectList(_context.Set<Vendor>(), "ID", "VendorName");
            return Page();
        }

        [BindProperty]
        public Product Product { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Product == null || Product == null)
            {
                return Page();
            }

            _context.Product.Add(Product);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
