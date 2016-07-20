using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrandReputation.Data.Entities.Mapping
{
    public static class UserExternalAuthenticationMap
    {
        public static void Map(this EntityTypeBuilder<UserExternalAuthentication> entity)
        {
            entity.Property(e => e.UserKey)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

            entity.HasOne(d => d.User)
                .WithMany(p => p.UserExternalAuthentication)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict)
                .HasConstraintName("FK_UserExternalAuthentication_User");
        }
    }
}
