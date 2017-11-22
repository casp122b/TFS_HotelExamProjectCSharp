using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class HotelExamContext : DbContext
    {
        static DbContextOptions<HotelExamContext> options = new DbContextOptionsBuilder<HotelExamContext>().UseInMemoryDatabase("InternalDb").Options;

        public HotelExamContext() : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<SingleRoom> Singles { get; set; }
        public DbSet<DoubleRoom> Doubles { get; set; }
        public DbSet<Suite> Suites { get; set; }
    }
}
