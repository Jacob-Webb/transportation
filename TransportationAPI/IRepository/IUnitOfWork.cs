using System;
using System.Threading.Tasks;
using TransportationAPI.Models;

namespace TransportationAPI.IRepository
{
    /// <summary>
    /// Follows the Unit of Work pattern <see href="https://www.c-sharpcorner.com/UploadFile/b1df45/unit-of-work-in-repository-pattern/"/> allowing all repositories to share the same DbContext. Creates <see cref="IGenericRepository{T}"/> of entities.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets the <see cref="IGenericRepository{T}"/> of entity type <see cref="ApplicationUser"/>.
        /// </summary>
        IGenericRepository<ApplicationUser> ApplicationUsers { get; }

        /// <summary>
        /// Gets the <see cref="IGenericRepository{T}"/> of entity type <see cref="CancelledRide"/>.
        /// </summary>
        IGenericRepository<CancelledRide> CancelledRides { get; }

        /// <summary>
        /// Gets the <see cref="IGenericRepository{T}"/> of entity type <see cref="Coordinate"/>.
        /// </summary>
        IGenericRepository<Coordinate> Coordinates { get; }

        /// <summary>
        /// Gets the <see cref="IGenericRepository{T}"/> of entity type <see cref="Driver"/>.
        /// </summary>
        IGenericRepository<Driver> Drivers { get; }

        /// <summary>
        /// Gets the <see cref="IGenericRepository{T}"/> of entity type <see cref="Gathering"/>.
        /// </summary>
        IGenericRepository<Gathering> Gatherings { get; }

        /// <summary>
        /// Gets the <see cref="IGenericRepository{T}"/> of entity type <see cref="GatheringTemplate"/>.
        /// </summary>
        IGenericRepository<GatheringTemplate> GatheringTemplates { get; }

        /// <summary>
        /// Gets the <see cref="IGenericRepository{T}"/> of entity type <see cref="GatheringTemplateBoundary"/>.
        /// </summary>
        IGenericRepository<GatheringTemplateBoundary> GatheringTemplateBoundaries { get; }

        /// <summary>
        /// Gets the <see cref="IGenericRepository{T}"/> of entity type <see cref="Note"/>.
        /// </summary>
        IGenericRepository<Note> Notes { get; }

        /// <summary>
        /// Gets the <see cref="IGenericRepository{T}"/> of entity type <see cref="Route"/>.
        /// </summary>
        IGenericRepository<Route> Routes { get; }

        /// <summary>
        /// Gets the <see cref="IGenericRepository{T}"/> of entity type <see cref="RouteDriver"/>.
        /// </summary>
        IGenericRepository<RouteDriver> RouteDrivers { get; }

        /// <summary>
        /// Gets the <see cref="IGenericRepository{T}"/> of entity type <see cref="ScheduledRide"/>.
        /// </summary>
        IGenericRepository<ScheduledRide> ScheduledRides { get; }

        /// <summary>
        /// Gets the <see cref="IGenericRepository{T}"/> of entity type <see cref="Source"/>.
        /// </summary>
        IGenericRepository<Source> Sources { get; }

        /// <summary>
        /// Gets the <see cref="IGenericRepository{T}"/> of entity type <see cref="TextHistory"/>.
        /// </summary>
        IGenericRepository<TextHistory> TextHistory { get; }

        /// <summary>
        /// Gets the <see cref="IGenericRepository{T}"/> of entity type <see cref="UserCoordinate"/>.
        /// </summary>
        IGenericRepository<UserCoordinate> UserCoordinates { get; }

        /// <summary>
        /// Gets the <see cref="IGenericRepository{T}"/> of entity type <see cref="UserNote"/>.
        /// </summary>
        IGenericRepository<UserNote> UserNotes { get; }

        /// <summary>
        /// Persists updates to the database.
        /// </summary>
        /// <returns>An instance of type <see cref="Task"/>.</returns>
        Task SaveAsync();

        /// <summary>
        /// Implements the Dispose method, primarily for releasing unmanaged resources.
        /// See documentation <see href="https://docs.microsoft.com/en-us/dotnet/standard/garbage-collection/implementing-dispose"/>.
        /// </summary>
        abstract void IDisposable.Dispose();
    }
}
