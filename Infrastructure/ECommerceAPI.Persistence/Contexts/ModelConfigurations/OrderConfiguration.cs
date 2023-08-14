using ECommerceAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence.Contexts.ModelConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
             .HasIndex(o => o.OrderCode)
            .IsUnique();

            builder
               .HasKey(x => x.Id);

            builder
                .HasOne(x => x.Basket)
                .WithOne(x => x.Order)
                .HasForeignKey<Order>(x => x.Id);
        }
    }
}
