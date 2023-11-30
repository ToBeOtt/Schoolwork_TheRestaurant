using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheRestaurant.Domain.Entities.OrderEntities;

namespace TheRestaurant.Common.Infrastructure.Data
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.Id)
                .IsRequired();

            builder.Property(o => o.OrderDate)
                .IsRequired();

            builder.HasMany(o => o.EmployeeOrders)
                .WithOne()
                .HasForeignKey("OrderId");

            builder.HasMany(o => o.OrderRows)
                .WithOne()
                .HasForeignKey("OrderId");
        }
    }

}
