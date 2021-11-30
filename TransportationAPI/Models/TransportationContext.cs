using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TransportationAPI.Configurations.Entities;

namespace TransportationAPI.Models
{
    public partial class TransportationContext : IdentityDbContext<ApplicationUser>
    {
        public TransportationContext()
        {
        }

        public TransportationContext(DbContextOptions<TransportationContext> options)
            : base(options)
        {
        }
        public virtual DbSet<CancelledRide> CancelledRides { get; set; }
        public virtual DbSet<Coordinate> Coordinates { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventTemplate> EventTemplates { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
        public virtual DbSet<Route> Routes { get; set; }
        public virtual DbSet<RouteDriver> RouteDriver { get; set; }
        public virtual DbSet<ScheduledRide> ScheduledRides { get; set; }
        public virtual DbSet<Source> Sources { get; set; }
        public virtual DbSet<TextHistory> TextHistory { get; set; }
        public virtual DbSet<UserCoordinate> UserCoordinates { get; set; }
        public virtual DbSet<UserNote> UserNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.Entity<CancelledRide>()
            .HasKey(cr => new { cr.ApplicationUserId, cr.EventId });

            modelBuilder.Entity<EventTemplateBoundary>()
            .HasKey(etb => new { etb.EventTemplateId, etb.CoordinateId });

            modelBuilder.Entity<RouteDriver>()
            .HasKey(rd => new { rd.RouteId, rd.DriverId });

            modelBuilder.Entity<UserCoordinate>()
            .HasKey(uc => new { uc.ApplicationUserId, uc.CoordinateId });

            modelBuilder.Entity<UserNote>()
            .HasKey(un => new { un.ApplicationUserId, un.NoteId });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
