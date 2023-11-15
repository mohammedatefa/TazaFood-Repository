using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazaFood_Core.Models.Order_Aggregate;

namespace TazaFood_Repository.Context.Model_Relations_Config
{
    public class OrderItemConifguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.OwnsOne(o => o.Product, Product => Product.WithOwner());
            builder.Property(o => o.Price).HasColumnType("decimal(18,2)");
        }
    }
}
