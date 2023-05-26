using BookingService.Domain.Entities;
using BookingService.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace BookingService.Infrastructure
{
    public class BookingServiceContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public BookingServiceContext(DbContextOptions<BookingServiceContext> options)
              : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly(typeof(BookingServiceContext).Assembly.FullName));
            }
        }

        public DbSet<Route> Routes { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Route>().HasKey(l => l.RouteId);
            modelBuilder.Entity<User>().HasKey(l => l.UserId);
            modelBuilder.Entity<Seat>().HasKey(l => l.SeatId);
        }
    }
}