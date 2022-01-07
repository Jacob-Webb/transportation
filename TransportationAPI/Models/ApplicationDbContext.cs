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

        public virtual DbSet<Gathering> Gatherings { get; set; }

        public virtual DbSet<GatheringTemplate> GatheringTemplates { get; set; }

        public virtual DbSet<GatheringTemplateBoundary> GatheringTemplateBoundaries { get; set; }

        public virtual DbSet<Note> Notes { get; set; }

        public virtual DbSet<Route> Routes { get; set; }

        public virtual DbSet<RouteDriver> RouteDrivers { get; set; }

        public virtual DbSet<ScheduledRide> ScheduledRides { get; set; }

        public virtual DbSet<Source> Sources { get; set; }

        public virtual DbSet<TextHistory> TextHistory { get; set; }

        public virtual DbSet<UserCoordinate> UserCoordinates { get; set; }

        public virtual DbSet<UserNote> UserNotes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());

            builder.Entity<Coordinate>()
            .HasKey(c => new { c.Latitude, c.Longitude });

            builder.Entity<CancelledRide>()
            .HasKey(cr => new { cr.ApplicationUserId, cr.GatheringId });

            builder.Entity<GatheringTemplateBoundary>()
            .HasKey(etb => new { etb.GatheringTemplateId, etb.CoordinateLatitude, etb.CoordinateLongitude });

            builder.Entity<RouteDriver>()
            .HasKey(rd => new { rd.RouteId, rd.DriverId });

            builder.Entity<UserCoordinate>()
            .HasKey(uc => new { uc.ApplicationUserId, uc.CoordinateLatitude, uc.CoordinateLongitude });

            builder.Entity<UserNote>()
            .HasKey(un => new { un.ApplicationUserId, un.NoteId });

#pragma warning disable S3251 // Implementations should be provided for "partial" methods
            OnModelCreatingPartial(builder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
#pragma warning restore S3251 // Implementations should be provided for "partial" methods
    }
}
