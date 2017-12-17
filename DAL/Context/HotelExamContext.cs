using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    public class HotelExamContext: DbContext
    {
        public HotelExamContext(DbContextOptions<HotelExamContext> options) : base(options)
        {
        }
        // static DbContextOptions<HotelExamContext> options = new DbContextOptionsBuilder<HotelExamContext>().UseInMemoryDatabase("InternalDb").Options;

        // public HotelExamContext() : base(options) { }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(@"Server=tcp:hotelexam.database.windows.net,1433;Initial Catalog=hoteldb;Persist Security Info=False;User ID=hahahahahahahaha5000;Password=azurefordenledeklingeA1@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //        Console.WriteLine("Ko");
        //    }
        // }

        //Defines relationships between entities
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<SingleRoom>()
                .HasOne(s => s.Guest)
                .WithMany(g => g.SingleRooms)
                .HasForeignKey(s => s.GuestId)
                .IsRequired(false);

            modelbuilder.Entity<DoubleRoom>()
                .HasOne(d => d.Guest)
                .WithMany(g => g.DoubleRooms)
                .HasForeignKey(d => d.GuestId)
                .IsRequired(false);

            modelbuilder.Entity<Suite>()
                .HasOne(s => s.Guest)
                .WithMany(g => g.Suites)
                .HasForeignKey(s => s.GuestId)
                .IsRequired(false);

            modelbuilder.Entity<Guest>()
                .HasOne(g => g.User)
                .WithOne(u => u.Guest)
                .HasForeignKey<Guest>(g => g.UserId)
                .IsRequired(true);

            modelbuilder.Entity<Admin>()
                .HasOne(a => a.User)
                .WithOne(u => u.Admin)
                .HasForeignKey<Admin>(a => a.UserId)
                .IsRequired(true);

            modelbuilder.Entity<Booking>()
                .HasOne(b => b.Guest)
                .WithMany(g => g.Bookings)
                .HasForeignKey(b => b.GuestId)
                .IsRequired(true);

            modelbuilder.Entity<Booking>()
                .HasOne(b => b.SingleRoom)
                .WithMany(g => g.Bookings)
                .HasForeignKey(b => b.SingleRoomId)
                .IsRequired(false);

            modelbuilder.Entity<Booking>()
                .HasOne(b => b.DoubleRoom)
                .WithMany(g => g.Bookings)
                .HasForeignKey(b => b.DoubleRoomId)
                .IsRequired(false);

            modelbuilder.Entity<Booking>()
                .HasOne(b => b.Suite)
                .WithMany(g => g.Bookings)
                .HasForeignKey(b => b.SuiteId)
                .IsRequired(false);

            base.OnModelCreating(modelbuilder);
        }

        // Saving to database
        public DbSet<Guest> Guests
        {
            get; set;
        }
        public DbSet<Admin> Admins
        {
            get; set;
        }
        public DbSet<User> Users
        {
            get; set;
        }
        public DbSet<Booking> Bookings
        {
            get; set;
        }
        public DbSet<SingleRoom> SingleRooms
        {
            get; set;
        }
        public DbSet<DoubleRoom> DoubleRooms
        {
            get; set;
        }
        public DbSet<Suite> Suites
        {
            get; set;
        }
    }
}