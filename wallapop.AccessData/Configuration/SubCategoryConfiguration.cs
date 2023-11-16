using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wallapop.Models.Models;

namespace wallapop.AccessData.Configuration
{
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.SubCatEnum).IsRequired();
        }
    }
}
