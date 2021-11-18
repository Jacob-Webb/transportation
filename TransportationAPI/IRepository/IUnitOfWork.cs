using System;
using System.Threading.Tasks;
using TransportationAPI.Data;

namespace TransportationAPI.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<ApplicationUser> ApplicationUsers { get; }
        IGenericRepository<CancelledRide> CancelledRides { get; }
        IGenericRepository<Coordinate> Coordinates { get; }
        IGenericRepository<Driver> Drivers { get; }
        IGenericRepository<Event> Events { get; }
        IGenericRepository<EventTemplate> EventTemplates { get; }
        IGenericRepository<Note> Notes { get; }
        IGenericRepository<Route> Routes { get; }
        IGenericRepository<RouteDriver> RouteDrivers { get; }
        IGenericRepository<ScheduledRide> ScheduledRides { get; }
        IGenericRepository<Source> Sources { get; }
        IGenericRepository<TextHistory> TextHistory { get; }
        IGenericRepository<UserCoordinate> UserCoordinates { get; }
        IGenericRepository<UserNote> UserNotes { get; }
        Task Save();
    }
}
