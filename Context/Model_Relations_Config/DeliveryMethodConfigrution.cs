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
    public class DeliveryMethodConfigrution : IEntityTypeConfiguration<DeliveryMethod>
    {
        public void Configure(EntityTypeBuilder<DeliveryMethod> builder)
        {
            builder.Property(o => o.Cost).HasColumnType("decimal(18,2)");
        }
    }
}
