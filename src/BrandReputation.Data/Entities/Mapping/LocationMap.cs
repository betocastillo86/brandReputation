using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrandReputation.Data.Entities.Mapping
{
    public static class LocationMap
    {
        public static void Map(this EntityTypeBuilder<Location> entity)
        {
            entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

            entity.HasOne(d => d.ParentLocation)
                .WithMany(p => p.InverseParentLocation)
                .HasForeignKey(d => d.ParentLocationId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Location_Location");
        }
    }
}
