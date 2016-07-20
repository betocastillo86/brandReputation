using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrandReputation.Data.Entities.Mapping
{
    public static class BrandAttributeMap
    {
        public static void Map(this EntityTypeBuilder<BrandAttribute> entity)
        {
            entity.Property(e => e.Attribute)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

            entity.Property(e => e.Value)
                .IsRequired()
                .HasColumnType("varchar(150)");

            entity.HasOne(d => d.Brand)
                .WithMany(p => p.BrandAttribute)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_BrandAttribute_Brand");
        }
    }
}
