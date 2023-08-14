using ECommerceAPI.Domain.Entities;
using ECommerceAPI.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using System.Reflection;

namespace ECommerceAPI.Persistence.Contexts
{
    public class ECommerceAPIDbContext : IdentityDbContext<AppUser, AppRole, Guid>
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


        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>()
                                    .HavePrecision(18, 2);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                if (data.Entity as BaseEntity != null)
                {
                    if (data.State == EntityState.Added)
                    {
                        data.Entity.CreatedDate = DateTime.Now;
                    }
                    if (data.State == EntityState.Modified)
                    {
                        data.Entity.UpdatedDate = DateTime.Now;

                    }
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
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

    }
}
