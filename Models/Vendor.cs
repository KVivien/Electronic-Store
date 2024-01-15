namespace Electronic_Store.Models
{
    public class Vendor
    {
        public int ID { get; set; }
        public string? VendorName { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
