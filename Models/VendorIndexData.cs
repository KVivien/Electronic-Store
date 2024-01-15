using System.Security.Policy;

namespace Electronic_Store.Models
{
    public class VendorIndexData
    {
        public IEnumerable<Vendor>? Vendors { get; set; }
        public IEnumerable<Product>? Products { get; set; }
    }
}
