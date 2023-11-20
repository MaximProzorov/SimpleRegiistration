﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SimpleRegistration.Api.Models;

#nullable disable

namespace SimpleRegistration.Api.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20231120133930_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SimpleRegistration.Api.Models.Country", b =>
                {
                    b.Property<Guid>("CountryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CountryId");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            CountryId = new Guid("a7905a21-e751-4eba-a6d5-9f2219de1a1a"),
                            Name = "Country 1"
                        },
                        new
                        {
                            CountryId = new Guid("3fd38400-55d6-44f3-bf52-ec46766085bb"),
                            Name = "Country 2"
                        });
                });

            modelBuilder.Entity("SimpleRegistration.Api.Models.Province", b =>
                {
                    b.Property<Guid>("ProvinceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProvinceId");

                    b.HasIndex("CountryId");

                    b.ToTable("Provinces");

                    b.HasData(
                        new
                        {
                            ProvinceId = new Guid("a7472bf4-b4a2-4d2d-91d6-da21f871c75c"),
                            CountryId = new Guid("a7905a21-e751-4eba-a6d5-9f2219de1a1a"),
                            Name = "Province 1.1"
                        },
                        new
                        {
                            ProvinceId = new Guid("dc85af11-4c6a-4b5d-9cc3-98fd4eddc6b9"),
                            CountryId = new Guid("a7905a21-e751-4eba-a6d5-9f2219de1a1a"),
                            Name = "Province 1.2"
                        },
                        new
                        {
                            ProvinceId = new Guid("c0c2bb51-1cf7-40e6-b60e-e38e68e51b7a"),
                            CountryId = new Guid("3fd38400-55d6-44f3-bf52-ec46766085bb"),
                            Name = "Province 2.1"
                        });
                });

            modelBuilder.Entity("SimpleRegistration.Api.Models.User", b =>
                {
                    b.Property<Guid>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProvinceId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId");

                    b.HasIndex("ProvinceId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SimpleRegistration.Api.Models.Province", b =>
                {
                    b.HasOne("SimpleRegistration.Api.Models.Country", "Country")
                        .WithMany("Provinces")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("SimpleRegistration.Api.Models.User", b =>
                {
                    b.HasOne("SimpleRegistration.Api.Models.Province", "Province")
                        .WithMany()
                        .HasForeignKey("ProvinceId");

                    b.Navigation("Province");
                });

            modelBuilder.Entity("SimpleRegistration.Api.Models.Country", b =>
                {
                    b.Navigation("Provinces");
                });
#pragma warning restore 612, 618
        }
    }
}