using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class HotelExamContext : DbContext
    {

        public HotelExamContext(DbContextOptions<HotelExamContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=tcp:hotelexam.database.windows.net,1433;Initial Catalog=HotelExamDB;Persist Security Info=False;User ID=hahahahahahahaha5000;Password=azurefordenledeklingeA1@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<SingleRoom> Singles { get; set; }
        public DbSet<DoubleRoom> Doubles { get; set; }
        public DbSet<Suite> Suites { get; set; }
    }
}
