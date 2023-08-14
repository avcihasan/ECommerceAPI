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
    internal class CompletedOrderConfiguration : IEntityTypeConfiguration<CompletedOrder>
    {
        public void Configure(EntityTypeBuilder<CompletedOrder> builder)
        {
            builder
              .HasKey(x => x.Id);
            builder
                 .HasOne(x => x.Order)
                .WithOne(x => x.ComplatedOrder)
                .HasForeignKey<CompletedOrder>(x => x.Id);
        }
    }
}
