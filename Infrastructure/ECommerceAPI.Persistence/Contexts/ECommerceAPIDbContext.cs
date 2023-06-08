using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace ECommerceAPI.Persistence.Contexts
{
    public class ECommerceAPIDbContext : IdentityDbContext<AppUser,AppRole,string>
    {
        public ECommerceAPIDbContext(DbContextOptions options) : base(options)
        { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CompletedOrder> ComplatedOrders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ECommerceAPI.Domain.Entities.File> Files { get; set; } 
        public DbSet<ProductImageFile> ProductImageFiles { get; set; }
        public DbSet<InvoiceFile> InvoiceFiles { get; set; }
        public DbSet<Controller> Controllers { get; set; }
        public DbSet<Endpoint> Endpoints { get; set; }




        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                if (data.Entity as BaseEntity != null)
                {
                    //if (data.State == EntityState.Added)
                    //{
                    //    data.Entity.CreatedDate = DateTime.Now;
                    //}
                    //if (data.State == EntityState.Modified)
                    //{
                    //    data.Entity.UpdatedDate = DateTime.Now;

                    //}
                    _ = data.State switch
                    {
                        EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                        EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                        _ => DateTime.UtcNow
                    };
                }

            }
            return await base.SaveChangesAsync(cancellationToken);
        }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompletedOrder>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<CompletedOrder>()
                .HasOne(x => x.Order)
                .WithOne(x => x.ComplatedOrder)
                .HasForeignKey<CompletedOrder>(x => x.Id);


            modelBuilder.Entity<Order>()
              .HasIndex(o => o.OrderCode)
              .IsUnique();

            modelBuilder.Entity<Order>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<Order>()
                .HasOne(x => x.Basket)
                .WithOne(x => x.Order)
                .HasForeignKey<Order>(x => x.Id);


            modelBuilder.Entity<ProductCategory>()
                .HasKey(key => new{ key.ProductId, key.CategoryId });

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Categories)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(c => c.Category)
                .HasForeignKey(c => c.CategoryId);

            modelBuilder.Entity<ProductDetail>()
                .HasKey(key => key.Id);

            modelBuilder.Entity<Product>()
                .HasOne(x => x.ProductDetails)
                .WithOne(x => x.Product)
                .HasForeignKey<ProductDetail>(x => x.Id);

            base.OnModelCreating(modelBuilder);

        }

    }
}
