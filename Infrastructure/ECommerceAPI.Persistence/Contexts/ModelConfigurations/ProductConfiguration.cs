using Bogus;
using ECommerceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Contexts.ModelConfigurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .HasOne(x => x.ProductDetails)
                .WithOne(x => x.Product)
                .HasForeignKey<ProductDetail>(x => x.Id);



            builder
              .HasMany(x => x.FavUsers)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductId);

            builder
               .HasMany(p => p.Categories)
               .WithOne(p => p.Product)
               .HasForeignKey(p => p.ProductId);

            builder.HasData(GetSeedProduct(100));
        }

        private List<Product> GetSeedProduct(int count)
        {
            var productFaker = new Faker<Product>("tr")
                 .RuleFor(x => x.Id, x => x.Random.Guid())
                 .RuleFor(x => x.Name, x => x.Commerce.ProductName())
                 .RuleFor(x => x.Price, x => x.Random.Decimal((decimal)1, (decimal)100000))
                 .RuleFor(x => x.Quantity, x => x.Random.Int(min: 0))
                 .RuleFor(x => x.Sale, x => x.Random.Bool())
                 .RuleFor(x => x.CreatedDate, x => x.Date.Between(DateTime.Now.AddYears(-10), DateTime.Now));
            return productFaker.Generate(count);
        }

    }
}
