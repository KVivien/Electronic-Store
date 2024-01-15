using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Electronic_Store.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public int? VendorID { get; set; }
        public Vendor? Vendor { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Quantity { get; set; }
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }
        public ICollection<ProductCategory>? ProductCategories { get; set; }

    }
}
