using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrandReputation.Data.Entities.Mapping
{
    public static class BrandTypeMap
    {
        public static void Map(this EntityTypeBuilder<BrandType> entity)
        {
            entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
        }
    }
}
