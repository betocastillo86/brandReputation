using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BrandReputation.Data
{
    public partial class BrandReputationContext : DbContext
    {
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //    optionsBuilder.UseSqlServer(@"Server=DESKTOP-DELL09\SQLEXPRESS;Database=BrandReputation;Trusted_Connection=True;");
        //}

        public BrandReputationContext(DbContextOptions<BrandReputationContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.AvgRating)
                    .HasColumnType("decimal")
                    .HasDefaultValueSql("0");

                entity.Property(e => e.CreationDateUtc).HasColumnType("datetime");

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.ModifiedDateUtc).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Brand)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_Brand_Location");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Brand)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Brand_User");
            });

            modelBuilder.Entity<BrandAttribute>(entity =>
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
            });

            modelBuilder.Entity<BrandRating>(entity =>
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
            });

            modelBuilder.Entity<BrandType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<BrandTypeBrand>(entity =>
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
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.ParentLocation)
                    .WithMany(p => p.InverseParentLocation)
                    .HasForeignKey(d => d.ParentLocationId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Location_Location");
            });

            modelBuilder.Entity<Rate>(entity =>
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
            });

            modelBuilder.Entity<User>(entity =>
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
            });

            modelBuilder.Entity<UserExternalAuthentication>(entity =>
            {
                entity.Property(e => e.UserKey)
                    .IsRequired()
                    .HasColumnType("varchar(50)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserExternalAuthentication)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_UserExternalAuthentication_User");
            });
        }

        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<BrandAttribute> BrandAttribute { get; set; }
        public virtual DbSet<BrandRating> BrandRating { get; set; }
        public virtual DbSet<BrandType> BrandType { get; set; }
        public virtual DbSet<BrandTypeBrand> BrandTypeBrand { get; set; }
        public virtual DbSet<Location> Location { get; set; }
        public virtual DbSet<Rate> Rate { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserExternalAuthentication> UserExternalAuthentication { get; set; }
    }
}