using System;
using System.Threading.Tasks;
using TransportationAPI.Models;
using TransportationAPI.IRepository;

namespace TransportationAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TransportationContext _context;
        private IGenericRepository<ApplicationUser> _applicationUser;
        private IGenericRepository<CancelledRide> _cancelledRide;
        private IGenericRepository<Coordinate> _coordinate;
        private IGenericRepository<Driver> _driver;
        private IGenericRepository<Event> _event;
        private IGenericRepository<EventTemplate> _eventTemplate;
        private IGenericRepository<EventTemplateBoundary> _eventTemplateBoundary;
        private IGenericRepository<Note> _note;
        private IGenericRepository<Route> _route;
        private IGenericRepository<RouteDriver> _routeDriver;
        private IGenericRepository<ScheduledRide> _scheduledRide;
        private IGenericRepository<Source> _source;
        private IGenericRepository<TextHistory> _textHistory;
        private IGenericRepository<UserCoordinate> _userCoordinate;
        private IGenericRepository<UserNote> _userNote;

        public UnitOfWork(TransportationContext context)
        {
            _context = context;
        }

        public IGenericRepository<ApplicationUser> ApplicationUsers => _applicationUser ??= new GenericRepository<ApplicationUser>(_context);
        public IGenericRepository<CancelledRide> CancelledRides => _cancelledRide ??= new GenericRepository<CancelledRide>(_context);
        public IGenericRepository<Coordinate> Coordinates => _coordinate ??= new GenericRepository<Coordinate>(_context);
        public IGenericRepository<Driver> Drivers => _driver ??= new GenericRepository<Driver>(_context);
        public IGenericRepository<Event> Events => _event ??= new GenericRepository<Event>(_context);
        public IGenericRepository<EventTemplate> EventTemplates => _eventTemplate ??= new GenericRepository<EventTemplate>(_context);
        public IGenericRepository<EventTemplateBoundary> EventTemplateBoundaries => _eventTemplateBoundary ??= new GenericRepository<EventTemplateBoundary>(_context);
        public IGenericRepository<Note> Notes => _note ??= new GenericRepository<Note>(_context);
        public IGenericRepository<Route> Routes => _route ??= new GenericRepository<Route>(_context);
        public IGenericRepository<RouteDriver> RouteDrivers => _routeDriver ??= new GenericRepository<RouteDriver>(_context);
        public IGenericRepository<ScheduledRide> ScheduledRides => _scheduledRide ??= new GenericRepository<ScheduledRide>(_context);
        public IGenericRepository<Source> Sources => _source ??= new GenericRepository<Source>(_context);
        public IGenericRepository<TextHistory> TextHistory => _textHistory ??= new GenericRepository<TextHistory>(_context);
        public IGenericRepository<UserCoordinate> UserCoordinates => _userCoordinate ??= new GenericRepository<UserCoordinate>(_context);
        public IGenericRepository<UserNote> UserNotes => _userNote ??= new GenericRepository<UserNote>(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
