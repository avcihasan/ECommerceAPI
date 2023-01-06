namespace ECommerceAPI.Domain.Entities
{
    public class Product:BaseEntity
    {
        public Product()
        {
            Categories = new HashSet<ProductCategory>();
        }
        public string Name { get; set; }
        public decimal  Price { get; set; }
        public int Quantity { get; set; }
        public bool Sale { get; set; }

        public ICollection<ProductCategory> Categories { get; set; }

        public ProductDetail ProductDetails { get; set; }

    }
}
