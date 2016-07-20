using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrandReputation.Data.Entities.Mapping
{
    public static class BrandRatingMap
    {
        public static void Map(this EntityTypeBuilder<BrandRating> entity)
        {
            entity.Property(e => e.AvgRating).HasColumnType("decimal");

            entity.Property(e => e.RatingType)
                .IsRequired()
                .HasColumnType("varchar(10)");

            entity.HasOne(d => d.Brand)
                .WithMany(p => p.BrandRating)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_BrandRating_Brand");
        }
    }
}
