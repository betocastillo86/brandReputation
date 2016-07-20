using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrandReputation.Data.Entities.Mapping
{
    public static class BrandTypeBrandMap
    {
        public static void Map(this EntityTypeBuilder<BrandTypeBrand> entity)
        {
            entity.HasOne(d => d.Brand)
                    .WithMany(p => p.BrandTypeBrand)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_BrandTypeBrand_Brand");

            entity.HasOne(d => d.BrandType)
                .WithMany(p => p.BrandTypeBrand)
                .HasForeignKey(d => d.BrandTypeId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_BrandTypeBrand_BrandType");
        }
    }
}
