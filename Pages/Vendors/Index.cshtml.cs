using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Electronic_Store.Data;
using Electronic_Store.Models;
using System.Security.Policy;

namespace Electronic_Store.Pages.Vendors
{
    public class IndexModel : PageModel
    {
        private readonly Electronic_Store.Data.Electronic_StoreContext _context;

        public IndexModel(Electronic_Store.Data.Electronic_StoreContext context)
        {
            _context = context;
        }

        public IList<Vendor> Vendor { get; set; } = default!;
        public VendorIndexData VendorData { get; set; }
        public int VendorID { get; set; }
        public int ProductID { get; set; }
        public async Task OnGetAsync(int? id, int? productID)
        {
            VendorData = new VendorIndexData();
            VendorData.Vendors = await _context.Vendor
                .Include(i => i.Products)
                .OrderBy(i => i.VendorName)
                .ToListAsync();
            if (id != null)
            {
                VendorID = id.Value;
                Vendor vendor = VendorData.Vendors
                .Where(i => i.ID == id.Value).Single();
                VendorData.Products = vendor.Products;
            }
        }
    }
}
