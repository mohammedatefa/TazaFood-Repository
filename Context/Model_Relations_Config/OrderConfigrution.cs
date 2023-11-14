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
    public class OrderConfigrution : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.OwnsOne(O => O.ShippingAddress, shippingAddress => shippingAddress.WithOwner());
            builder.Property(o => o.OrderStaus)
                .HasConversion(
                    o => o.ToString(),
                    o => (DeliveryStatus)Enum.Parse(typeof(DeliveryStatus), o)
                );
            builder.Property(o => o.SubTotal).HasColumnType("decimal(18,2)");
        }
    }
}
