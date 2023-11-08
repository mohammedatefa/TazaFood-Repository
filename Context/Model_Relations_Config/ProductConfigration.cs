using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TazaFood_Core.Models;

namespace TazaFood_Repository.Context.Model_Relations_Config
{
    internal class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p=>p.Category).WithMany().HasForeignKey(p=>p.CategoryId).OnDelete(DeleteBehavior.NoAction);

        }
    }
}
