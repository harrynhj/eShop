﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShippingService.Infrastructure.Data;

#nullable disable

namespace ShippingService.Infrastructure.Migrations
{
    [DbContext(typeof(ShippingDbContext))]
    [Migration("20250609092025_ShippingInit1")]
    partial class ShippingInit1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShippingService.ApplicationCore.Entities.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("ShippingService.ApplicationCore.Entities.Shipper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContactPerson")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Contact_Person");

                    b.Property<string>("EmailId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Shippers");
                });

            modelBuilder.Entity("ShippingService.ApplicationCore.Entities.ShipperRegion", b =>
                {
                    b.Property<int>("RegionId")
                        .HasColumnType("int")
                        .HasColumnName("Region_Id");

                    b.Property<int>("ShipperId")
                        .HasColumnType("int")
                        .HasColumnName("Shipper_Id");

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.HasKey("RegionId", "ShipperId");

                    b.HasIndex("ShipperId");

                    b.ToTable("Shipper_Region");
                });

            modelBuilder.Entity("ShippingService.ApplicationCore.Entities.ShippingDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("OrderId")
                        .HasColumnType("int")
                        .HasColumnName("Order_Id");

                    b.Property<int>("ShipperId")
                        .HasColumnType("int")
                        .HasColumnName("Shipper_Id");

                    b.Property<string>("ShippingStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Shipping_Status");

                    b.Property<string>("TrackingNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Shipping_Number");

                    b.HasKey("Id");

                    b.HasIndex("ShipperId");

                    b.ToTable("Shipping_Details");
                });

            modelBuilder.Entity("ShippingService.ApplicationCore.Entities.ShipperRegion", b =>
                {
                    b.HasOne("ShippingService.ApplicationCore.Entities.Region", "Region")
                        .WithMany("ShipperRegions")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ShippingService.ApplicationCore.Entities.Shipper", "Shipper")
                        .WithMany("ShipperRegions")
                        .HasForeignKey("ShipperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Region");

                    b.Navigation("Shipper");
                });

            modelBuilder.Entity("ShippingService.ApplicationCore.Entities.ShippingDetail", b =>
                {
                    b.HasOne("ShippingService.ApplicationCore.Entities.Shipper", "Shipper")
                        .WithMany("ShippingDetails")
                        .HasForeignKey("ShipperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shipper");
                });

            modelBuilder.Entity("ShippingService.ApplicationCore.Entities.Region", b =>
                {
                    b.Navigation("ShipperRegions");
                });

            modelBuilder.Entity("ShippingService.ApplicationCore.Entities.Shipper", b =>
                {
                    b.Navigation("ShipperRegions");

                    b.Navigation("ShippingDetails");
                });
#pragma warning restore 612, 618
        }
    }
}
