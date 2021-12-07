﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TransportationAPI.Models;

namespace TransportationAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20211206162842_login-refresh")]
    partial class loginrefresh
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = "846e2632-f96f-455b-8816-ad8cf17e1d97",
                            ConcurrencyStamp = "43673e23-57c1-4495-9813-87507ebd0c22",
                            Name = "SuperAdmin",
                            NormalizedName = "SUPERADMIN"
                        },
                        new
                        {
                            Id = "8c58fd63-e85f-42e8-8000-0d39a88b4b08",
                            ConcurrencyStamp = "399f50f4-ed04-410b-82af-1247d5e8947b",
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR"
                        },
                        new
                        {
                            Id = "deffb0b8-79f0-4b91-8d59-29c4ae1728d8",
                            ConcurrencyStamp = "c034831b-79bb-4c73-b146-493c3d55808b",
                            Name = "Driver",
                            NormalizedName = "DRIVER"
                        },
                        new
                        {
                            Id = "a28af549-b22c-43c4-974f-fc86ff5c2e09",
                            ConcurrencyStamp = "972434ed-9120-4170-9246-3417f07a8218",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TransportationAPI.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RefreshTokenExpiryTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("RequiresWheelchair")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("ZipCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TransportationAPI.Models.CancelledRide", b =>
                {
                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int?>("NoteId")
                        .HasColumnType("int");

                    b.Property<int?>("SourceId")
                        .HasColumnType("int");

                    b.HasKey("ApplicationUserId", "EventId");

                    b.HasIndex("EventId");

                    b.HasIndex("NoteId");

                    b.HasIndex("SourceId");

                    b.ToTable("CancelledRides");
                });

            modelBuilder.Entity("TransportationAPI.Models.Coordinate", b =>
                {
                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.HasKey("Latitude", "Longitude");

                    b.ToTable("Coordinates");
                });

            modelBuilder.Entity("TransportationAPI.Models.Driver", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.ToTable("Drivers");
                });

            modelBuilder.Entity("TransportationAPI.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EventDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("TemplateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TemplateId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("TransportationAPI.Models.EventTemplate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<int>("DriversNeeded")
                        .HasColumnType("int");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("TimeOfDay")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.ToTable("EventTemplates");
                });

            modelBuilder.Entity("TransportationAPI.Models.EventTemplateBoundary", b =>
                {
                    b.Property<int>("EventTemplateId")
                        .HasColumnType("int");

                    b.Property<double>("CoordinateLatitude")
                        .HasColumnType("float");

                    b.Property<double>("CoordinateLongitude")
                        .HasColumnType("float");

                    b.HasKey("EventTemplateId", "CoordinateLatitude", "CoordinateLongitude");

                    b.HasIndex("CoordinateLatitude", "CoordinateLongitude");

                    b.ToTable("EventTemplateBoundaries");
                });

            modelBuilder.Entity("TransportationAPI.Models.Note", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Notes");
                });

            modelBuilder.Entity("TransportationAPI.Models.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("TransportationAPI.Models.RouteDriver", b =>
                {
                    b.Property<int>("RouteId")
                        .HasColumnType("int");

                    b.Property<int>("DriverId")
                        .HasColumnType("int");

                    b.HasKey("RouteId", "DriverId");

                    b.HasIndex("DriverId");

                    b.ToTable("RouteDrivers");
                });

            modelBuilder.Entity("TransportationAPI.Models.ScheduledRide", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("EventId")
                        .HasColumnType("int");

                    b.Property<int>("PassengerCount")
                        .HasColumnType("int");

                    b.Property<int?>("RouteId")
                        .HasColumnType("int");

                    b.Property<int?>("SourceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimeScheduled")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("EventId");

                    b.HasIndex("RouteId");

                    b.HasIndex("SourceId");

                    b.ToTable("ScheduledRides");
                });

            modelBuilder.Entity("TransportationAPI.Models.Source", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MediaType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sources");
                });

            modelBuilder.Entity("TransportationAPI.Models.TextHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TextTimeStamp")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("TextHistory");
                });

            modelBuilder.Entity("TransportationAPI.Models.UserCoordinate", b =>
                {
                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("CoordinateLatitude")
                        .HasColumnType("float");

                    b.Property<double>("CoordinateLongitude")
                        .HasColumnType("float");

                    b.HasKey("ApplicationUserId", "CoordinateLatitude", "CoordinateLongitude");

                    b.HasIndex("CoordinateLatitude", "CoordinateLongitude");

                    b.ToTable("UserCoordinates");
                });

            modelBuilder.Entity("TransportationAPI.Models.UserNote", b =>
                {
                    b.Property<string>("ApplicationUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("NoteId")
                        .HasColumnType("int");

                    b.HasKey("ApplicationUserId", "NoteId");

                    b.HasIndex("NoteId");

                    b.ToTable("UserNotes");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TransportationAPI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TransportationAPI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransportationAPI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TransportationAPI.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TransportationAPI.Models.CancelledRide", b =>
                {
                    b.HasOne("TransportationAPI.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("CancelledRides")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransportationAPI.Models.Event", "Event")
                        .WithMany("CancelledRides")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransportationAPI.Models.Note", "Note")
                        .WithMany("CancelledRides")
                        .HasForeignKey("NoteId");

                    b.HasOne("TransportationAPI.Models.Source", "Source")
                        .WithMany()
                        .HasForeignKey("SourceId");

                    b.Navigation("ApplicationUser");

                    b.Navigation("Event");

                    b.Navigation("Note");

                    b.Navigation("Source");
                });

            modelBuilder.Entity("TransportationAPI.Models.Driver", b =>
                {
                    b.HasOne("TransportationAPI.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("TransportationAPI.Models.Event", b =>
                {
                    b.HasOne("TransportationAPI.Models.EventTemplate", "Template")
                        .WithMany()
                        .HasForeignKey("TemplateId");

                    b.Navigation("Template");
                });

            modelBuilder.Entity("TransportationAPI.Models.EventTemplateBoundary", b =>
                {
                    b.HasOne("TransportationAPI.Models.EventTemplate", "EventTemplates")
                        .WithMany("EventTemplateBoundaries")
                        .HasForeignKey("EventTemplateId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransportationAPI.Models.Coordinate", "Coordinates")
                        .WithMany("EventTemplateBoundaries")
                        .HasForeignKey("CoordinateLatitude", "CoordinateLongitude")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Coordinates");

                    b.Navigation("EventTemplates");
                });

            modelBuilder.Entity("TransportationAPI.Models.Route", b =>
                {
                    b.HasOne("TransportationAPI.Models.Event", "Event")
                        .WithMany("Routes")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Event");
                });

            modelBuilder.Entity("TransportationAPI.Models.RouteDriver", b =>
                {
                    b.HasOne("TransportationAPI.Models.Driver", "Driver")
                        .WithMany("RouteDrivers")
                        .HasForeignKey("DriverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransportationAPI.Models.Route", "Route")
                        .WithMany("RouteDrivers")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Driver");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("TransportationAPI.Models.ScheduledRide", b =>
                {
                    b.HasOne("TransportationAPI.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("ScheduledRides")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("TransportationAPI.Models.Event", "Event")
                        .WithMany("ScheduledRides")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransportationAPI.Models.Route", "Route")
                        .WithMany("ScheduledRides")
                        .HasForeignKey("RouteId");

                    b.HasOne("TransportationAPI.Models.Source", "Source")
                        .WithMany()
                        .HasForeignKey("SourceId");

                    b.Navigation("ApplicationUser");

                    b.Navigation("Event");

                    b.Navigation("Route");

                    b.Navigation("Source");
                });

            modelBuilder.Entity("TransportationAPI.Models.UserCoordinate", b =>
                {
                    b.HasOne("TransportationAPI.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("UserCoordinates")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransportationAPI.Models.Coordinate", "Coordinate")
                        .WithMany("UserCoordinates")
                        .HasForeignKey("CoordinateLatitude", "CoordinateLongitude")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Coordinate");
                });

            modelBuilder.Entity("TransportationAPI.Models.UserNote", b =>
                {
                    b.HasOne("TransportationAPI.Models.ApplicationUser", "ApplicationUser")
                        .WithMany("UserNotes")
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TransportationAPI.Models.Note", "Note")
                        .WithMany("UserNotes")
                        .HasForeignKey("NoteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Note");
                });

            modelBuilder.Entity("TransportationAPI.Models.ApplicationUser", b =>
                {
                    b.Navigation("CancelledRides");

                    b.Navigation("ScheduledRides");

                    b.Navigation("UserCoordinates");

                    b.Navigation("UserNotes");
                });

            modelBuilder.Entity("TransportationAPI.Models.Coordinate", b =>
                {
                    b.Navigation("EventTemplateBoundaries");

                    b.Navigation("UserCoordinates");
                });

            modelBuilder.Entity("TransportationAPI.Models.Driver", b =>
                {
                    b.Navigation("RouteDrivers");
                });

            modelBuilder.Entity("TransportationAPI.Models.Event", b =>
                {
                    b.Navigation("CancelledRides");

                    b.Navigation("Routes");

                    b.Navigation("ScheduledRides");
                });

            modelBuilder.Entity("TransportationAPI.Models.EventTemplate", b =>
                {
                    b.Navigation("EventTemplateBoundaries");
                });

            modelBuilder.Entity("TransportationAPI.Models.Note", b =>
                {
                    b.Navigation("CancelledRides");

                    b.Navigation("UserNotes");
                });

            modelBuilder.Entity("TransportationAPI.Models.Route", b =>
                {
                    b.Navigation("RouteDrivers");

                    b.Navigation("ScheduledRides");
                });
#pragma warning restore 612, 618
        }
    }
}