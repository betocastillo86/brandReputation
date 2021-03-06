﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BrandReputation.Data;

namespace BrandReputation.Data.Migrations
{
    [DbContext(typeof(BrandReputationContext))]
    [Migration("20160720152659_FirstMigration")]
    partial class FirstMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BrandReputation.Data.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("AvgRating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("decimal")
                        .HasDefaultValueSql("0");

                    b.Property<int?>("CountryId");

                    b.Property<DateTime>("CreationDateUtc")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<DateTime?>("ModifiedDateUtc")
                        .HasColumnType("datetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex("UserId");

                    b.ToTable("Brand");
                });

            modelBuilder.Entity("BrandReputation.Data.BrandAttribute", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Attribute")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<int>("BrandId");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("BrandAttribute");
                });

            modelBuilder.Entity("BrandReputation.Data.BrandRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("AvgRating")
                        .HasColumnType("decimal");

                    b.Property<int>("BrandId");

                    b.Property<int>("EntityId");

                    b.Property<int>("Position");

                    b.Property<string>("RatingType")
                        .IsRequired()
                        .HasColumnType("varchar(10)");

                    b.Property<int>("Votes");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("BrandRating");
                });

            modelBuilder.Entity("BrandReputation.Data.BrandType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.HasKey("Id");

                    b.ToTable("BrandType");
                });

            modelBuilder.Entity("BrandReputation.Data.BrandTypeBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrandId");

                    b.Property<int>("BrandTypeId");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("BrandTypeId");

                    b.ToTable("BrandTypeBrand");
                });

            modelBuilder.Entity("BrandReputation.Data.Location", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Deleted");

                    b.Property<string>("Name");

                    b.Property<int?>("ParentLocationId");

                    b.HasKey("Id");

                    b.HasIndex("ParentLocationId");

                    b.ToTable("Location");
                });

            modelBuilder.Entity("BrandReputation.Data.Rate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BrandId");

                    b.Property<DateTime>("CreationDateUtc");

                    b.Property<bool>("Deleted");

                    b.Property<byte>("Rating");

                    b.Property<string>("Text");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("UserId");

                    b.ToTable("Rate");
                });

            modelBuilder.Entity("BrandReputation.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CountryId");

                    b.Property<DateTime>("CreationDateUtc");

                    b.Property<int>("Email");

                    b.Property<int>("Name");

                    b.Property<string>("Password");

                    b.Property<int>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BrandReputation.Data.UserExternalAuthentication", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ExternalAuthenticationTypeId");

                    b.Property<int>("UserId");

                    b.Property<string>("UserKey");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserExternalAuthentication");
                });

            modelBuilder.Entity("BrandReputation.Data.Brand", b =>
                {
                    b.HasOne("BrandReputation.Data.Location", "Country")
                        .WithMany("Brand")
                        .HasForeignKey("CountryId")
                        .HasConstraintName("FK_Brand_Location");

                    b.HasOne("BrandReputation.Data.User", "User")
                        .WithMany("Brand")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Brand_User");
                });

            modelBuilder.Entity("BrandReputation.Data.BrandAttribute", b =>
                {
                    b.HasOne("BrandReputation.Data.Brand", "Brand")
                        .WithMany("BrandAttribute")
                        .HasForeignKey("BrandId")
                        .HasConstraintName("FK_BrandAttribute_Brand");
                });

            modelBuilder.Entity("BrandReputation.Data.BrandRating", b =>
                {
                    b.HasOne("BrandReputation.Data.Brand", "Brand")
                        .WithMany("BrandRating")
                        .HasForeignKey("BrandId")
                        .HasConstraintName("FK_BrandRating_Brand");
                });

            modelBuilder.Entity("BrandReputation.Data.BrandTypeBrand", b =>
                {
                    b.HasOne("BrandReputation.Data.Brand", "Brand")
                        .WithMany("BrandTypeBrand")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BrandReputation.Data.BrandType", "BrandType")
                        .WithMany("BrandTypeBrand")
                        .HasForeignKey("BrandTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BrandReputation.Data.Location", b =>
                {
                    b.HasOne("BrandReputation.Data.Location", "ParentLocation")
                        .WithMany("InverseParentLocation")
                        .HasForeignKey("ParentLocationId");
                });

            modelBuilder.Entity("BrandReputation.Data.Rate", b =>
                {
                    b.HasOne("BrandReputation.Data.Brand", "Brand")
                        .WithMany("Rate")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BrandReputation.Data.User", "User")
                        .WithMany("Rate")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BrandReputation.Data.User", b =>
                {
                    b.HasOne("BrandReputation.Data.Location", "Country")
                        .WithMany("User")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BrandReputation.Data.UserExternalAuthentication", b =>
                {
                    b.HasOne("BrandReputation.Data.User", "User")
                        .WithMany("UserExternalAuthentication")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
