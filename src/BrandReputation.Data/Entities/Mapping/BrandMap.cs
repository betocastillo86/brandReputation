using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrandReputation.Data.Entities.Mapping
{
    public static class BrandMap
    {
        public static void Map(this EntityTypeBuilder<Brand> table)
        {
            table.Property(e => e.AvgRating)
                    .HasColumnType("decimal")
                    .HasDefaultValueSql("0");

            table.Property(e => e.CreationDateUtc).HasColumnType("datetime");

            table.Property(e => e.Description).IsRequired();

            table.Property(e => e.ModifiedDateUtc).HasColumnType("datetime");

            table.Property(e => e.Name)
                .IsRequired()
                .HasColumnType("varchar(50)");

            table.HasOne(d => d.Country)
                .WithMany(p => p.Brand)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_Brand_Location");

            table.HasOne(d => d.User)
                .WithMany(p => p.Brand)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_Brand_User");
        }
    }
}
