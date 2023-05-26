using BookingService.Domain.Entities;
using BookingService.Domain.Repositories;

namespace BookingService.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private BookingServiceContext _bookingServiceContext;
        private IBaseRepository<User> _userRepository;
        private IBaseRepository<Route> _routeRepository;

        public UnitOfWork(BookingServiceContext bookingServiceContext)
        {
            _bookingServiceContext = bookingServiceContext;
        }

        public IBaseRepository<User> UserRepository
        {
            get
            {

                if (_userRepository == null)
                {
                    _userRepository = new BaseRepository<User>(_bookingServiceContext);
                }
                return _userRepository;
            }
        }
        public IBaseRepository<Route> RideRepository
        {
            get
            {

                if (_routeRepository == null)
                {
                    _routeRepository = new BaseRepository<Route>(_bookingServiceContext);
                }
                return _routeRepository;
            }
        }
        public async Task SaveChangesAsync()
        {
            await _bookingServiceContext.SaveChangesAsync();
        }
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _bookingServiceContext.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
