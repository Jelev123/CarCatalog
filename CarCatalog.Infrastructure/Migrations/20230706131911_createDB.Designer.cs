﻿// <auto-generated />
using CarCatalog.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarCatalog.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230706131911_createDB")]
    partial class createDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarCatalog.Infrastructure.Data.Models.BodyType", b =>
                {
                    b.Property<int>("BodyTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BodyTypeId"), 1L, 1);

                    b.Property<string>("BodyTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Doors")
                        .HasColumnType("int");

                    b.HasKey("BodyTypeId");

                    b.ToTable("BodyTypes");
                });

            modelBuilder.Entity("CarCatalog.Infrastructure.Data.Models.Car", b =>
                {
                    b.Property<int>("CarId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CarId"), 1L, 1);

                    b.Property<string>("CarBrand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CarModel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FuelType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("HorsePower")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("CarId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarCatalog.Infrastructure.Data.Models.CarBodyType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BodyTypeId")
                        .HasColumnType("int");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BodyTypeId");

                    b.HasIndex("CarId");

                    b.ToTable("CarBodyTypes");
                });

            modelBuilder.Entity("CarCatalog.Infrastructure.Data.Models.CarTransmision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("TransmisionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("TransmisionId");

                    b.ToTable("CarTransmisions");
                });

            modelBuilder.Entity("CarCatalog.Infrastructure.Data.Models.Images", b =>
                {
                    b.Property<string>("ImageId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("URL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ImageId");

                    b.HasIndex("CarId");

                    b.ToTable("Images");
                });

            modelBuilder.Entity("CarCatalog.Infrastructure.Data.Models.Transmision", b =>
                {
                    b.Property<int>("TransmisionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransmisionId"), 1L, 1);

                    b.Property<int>("Gears")
                        .HasColumnType("int");

                    b.Property<string>("TransmisionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TransmisionId");

                    b.ToTable("Transmisions");
                });

            modelBuilder.Entity("CarCatalog.Infrastructure.Data.Models.CarBodyType", b =>
                {
                    b.HasOne("CarCatalog.Infrastructure.Data.Models.BodyType", "BodyType")
                        .WithMany()
                        .HasForeignKey("BodyTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarCatalog.Infrastructure.Data.Models.Car", "Car")
                        .WithMany("CarBodyTypes")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BodyType");

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarCatalog.Infrastructure.Data.Models.CarTransmision", b =>
                {
                    b.HasOne("CarCatalog.Infrastructure.Data.Models.Car", "Car")
                        .WithMany("CarTransmisions")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarCatalog.Infrastructure.Data.Models.Transmision", "Transmision")
                        .WithMany()
                        .HasForeignKey("TransmisionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("Transmision");
                });

            modelBuilder.Entity("CarCatalog.Infrastructure.Data.Models.Images", b =>
                {
                    b.HasOne("CarCatalog.Infrastructure.Data.Models.Car", "Car")
                        .WithMany("Images")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarCatalog.Infrastructure.Data.Models.Car", b =>
                {
                    b.Navigation("CarBodyTypes");

                    b.Navigation("CarTransmisions");

                    b.Navigation("Images");
                });
#pragma warning restore 612, 618
        }
    }
}
