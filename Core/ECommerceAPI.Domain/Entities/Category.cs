namespace ECommerceAPI.Domain.Entities
{
    public class Category:BaseEntity
    {
        public Category()
        {
            Products = new HashSet<ProductCategory>();
        }
        public string Name { get; set; }
        public ICollection<ProductCategory> Products { get; set; }
    }
}
