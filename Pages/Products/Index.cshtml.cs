using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Electronic_Store.Data;
using Electronic_Store.Models;

namespace Electronic_Store.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly Electronic_Store.Data.Electronic_StoreContext _context;

        public IndexModel(Electronic_Store.Data.Electronic_StoreContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;
        public ProductData ProductD { get; set; }
        public int ProductID { get; set; }
        public int CategoryID { get; set; }
        public string CurrentFilter { get; set; }
        public async Task OnGetAsync(string searchString)
        {
            ProductD = new ProductData();
            CurrentFilter = searchString;



            if (_context.Product != null)
            {
                Product = await _context.Product
                    .Include(b => b.Vendor)
                    .ToListAsync();
                if (!String.IsNullOrEmpty(searchString))
                {
                    ProductD.Products = ProductD.Products.Where(s => s.Name.Contains(searchString) || s.Name.Contains(searchString));
                 //  || s.Vendor.Contains(searchString);
                }
            }
        }
    }
}
