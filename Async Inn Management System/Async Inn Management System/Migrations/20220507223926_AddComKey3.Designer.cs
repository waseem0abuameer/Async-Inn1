﻿// <auto-generated />
using Async_Inn_Management_System.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Async_Inn_Management_System.Migrations
{
    [DbContext(typeof(HotelDbContext))]
    [Migration("20220507223926_AddComKey3")]
    partial class AddComKey3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Async_Inn_Management_System.Models.Amenity", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Amenities");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = " air conditioner"
                        },
                        new
                        {
                            ID = 2,
                            Name = "television"
                        },
                        new
                        {
                            ID = 3,
                            Name = "look"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Children's bed"
                        });
                });

            modelBuilder.Entity("Async_Inn_Management_System.Models.Hotel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Address = "Irbid",
                            City = "Irbid",
                            Name = "Async Inn-Irbid",
                            Phone = "02665200",
                            State = "jordan"
                        },
                        new
                        {
                            ID = 2,
                            Address = "WadiRum",
                            City = "Aqaba",
                            Name = "Async Inn-WadiRum",
                            Phone = "02665201",
                            State = "jordan"
                        },
                        new
                        {
                            ID = 3,
                            Address = "Amman",
                            City = "Amman",
                            Name = "Async Inn-Amman",
                            Phone = "02665202",
                            State = "jordan"
                        });
                });

            modelBuilder.Entity("Async_Inn_Management_System.Models.HotelRoom", b =>
                {
                    b.Property<int>("HotelID")
                        .HasColumnType("int");

                    b.Property<int>("RoomID")
                        .HasColumnType("int");

                    b.Property<int>("ID")
                        .HasColumnType("int");

                    b.Property<bool>("PetFriendly")
                        .HasColumnType("bit");

                    b.Property<decimal>("Rate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int");

                    b.HasKey("HotelID", "RoomID");

                    b.HasIndex("RoomID");

                    b.ToTable("HotelRooms");
                });

            modelBuilder.Entity("Async_Inn_Management_System.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Layout")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Rooms");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Layout = 0,
                            Name = "One Bedrooms "
                        },
                        new
                        {
                            ID = 2,
                            Layout = 1,
                            Name = "Two Bedrooms"
                        },
                        new
                        {
                            ID = 3,
                            Layout = 2,
                            Name = "Studio"
                        });
                });

            modelBuilder.Entity("Async_Inn_Management_System.Models.HotelRoom", b =>
                {
                    b.HasOne("Async_Inn_Management_System.Models.Hotel", "Hotel")
                        .WithMany("HotelRoom")
                        .HasForeignKey("HotelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Async_Inn_Management_System.Models.Room", "Room")
                        .WithMany("HotelRoom")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hotel");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Async_Inn_Management_System.Models.Hotel", b =>
                {
                    b.Navigation("HotelRoom");
                });

            modelBuilder.Entity("Async_Inn_Management_System.Models.Room", b =>
                {
                    b.Navigation("HotelRoom");
                });
#pragma warning restore 612, 618
        }
    }
}
