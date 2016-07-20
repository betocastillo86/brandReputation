using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrandReputation.Data.Entities.Mapping
{
    public static class UserMap
    {
        public static void Map(this EntityTypeBuilder<User> entity)
        {
            entity.HasIndex(e => e.Email)
                    .HasName("IX_User_Email")
                    .IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.CreationDateUtc).HasColumnType("datetime");

            entity.Property(e => e.Name).ValueGeneratedOnAdd();

            entity.Property(e => e.Password)
                .IsRequired()
                .HasColumnType("varchar(50)");

            entity.HasOne(d => d.Country)
                .WithMany(p => p.User)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_User_Location");
        }
    }
}
