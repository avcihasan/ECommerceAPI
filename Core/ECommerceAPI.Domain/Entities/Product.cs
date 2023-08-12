namespace ECommerceAPI.Domain.Entities
{
    public class Product:BaseEntity
    {
        public Product()
        {
            Categories = new HashSet<ProductCategory>();
            ProductImageFiles = new HashSet<ProductImageFile>();
            BasketItems = new HashSet<BasketItem>();
            FavUsers = new HashSet<FavoriteProduct>();
        }
        public string Name { get; set; }
        public decimal  Price { get; set; }
        public int Quantity { get; set; }
        public bool Sale { get; set; }

        public ICollection<ProductCategory> Categories { get; set; }

        public ProductDetail ProductDetails { get; set; }

        public ICollection<ProductImageFile> ProductImageFiles { get; set; }
        public ICollection<BasketItem> BasketItems { get; set; }
        public ICollection<FavoriteProduct> FavUsers { get; set; }

    }
}
