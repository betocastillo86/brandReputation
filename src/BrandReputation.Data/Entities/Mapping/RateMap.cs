using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrandReputation.Data.Entities.Mapping
{
    public static class RateMap
    {
        public static void Map(this EntityTypeBuilder<Rate> entity)
        {
            entity.Property(e => e.CreationDateUtc).HasColumnType("datetime");

            entity.Property(e => e.Text).IsRequired();

            entity.HasOne(d => d.Brand)
                .WithMany(p => p.Rate)
                .HasForeignKey(d => d.BrandId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Rate_Brand");

            entity.HasOne(d => d.User)
                .WithMany(p => p.Rate)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Rate_User");
        }
    }
}
