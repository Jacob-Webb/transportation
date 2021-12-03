using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TransportationAPI.Configurations.Entities;

namespace TransportationAPI.Models
{
    public partial class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<CancelledRide> CancelledRides { get; set; }
        public virtual DbSet<Coordinate> Coordinates { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventTemplate> EventTemplates { get; set; }
        public virtual DbSet<EventTemplateBoundary> EventTemplateBoundaries { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<RouteDriver> RouteDrivers { get; set; }
        public virtual DbSet<ScheduledRide> ScheduledRides { get; set; }
        public virtual DbSet<Source> Sources { get; set; }
        public virtual DbSet<TextHistory> TextHistory { get; set; }
        public virtual DbSet<UserCoordinate> UserCoordinates { get; set; }
        public virtual DbSet<UserNote> UserNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.Entity<Coordinate>()
            .HasKey(c => new { c.Latitude, c.Longitude });

            modelBuilder.Entity<CancelledRide>()
            .HasKey(cr => new { cr.ApplicationUserId, cr.EventId });

            modelBuilder.Entity<EventTemplateBoundary>()
            .HasKey(etb => new { etb.EventTemplateId, etb.CoordinateLatitude, etb.CoordinateLongitude });

            modelBuilder.Entity<RouteDriver>()
            .HasKey(rd => new { rd.RouteId, rd.DriverId });

            modelBuilder.Entity<UserCoordinate>()
            .HasKey(uc => new { uc.ApplicationUserId, uc.CoordinateLatitude, uc.CoordinateLongitude });

            modelBuilder.Entity<UserNote>()
            .HasKey(un => new { un.ApplicationUserId, un.NoteId });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
