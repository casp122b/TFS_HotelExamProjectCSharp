using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DAL.Context
{
    public class HotelExamContext : DbContext
    {
        public HotelExamContext(DbContextOptions<HotelExamContext> options) : base(options)
        {

        }
        //static DbContextOptions<HotelExamContext> options = new DbContextOptionsBuilder<HotelExamContext>().UseInMemoryDatabase("InternalDb").Options;

        //public HotelExamContext() : base(options) { }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(@"Server=tcp:hotelexam.database.windows.net,1433;Initial Catalog=hoteldb;Persist Security Info=False;User ID=hahahahahahahaha5000;Password=azurefordenledeklingeA1@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        //        Console.WriteLine("Ko");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<GuestBooking>()
            //    .HasKey(gb => new { gb.GuestId, gb.BookingId });

            //modelBuilder.Entity<GuestBooking>()
            //    .HasOne(gb => gb.Guest)
            //    .WithMany(g => g.Bookings)
            //    .HasForeignKey(gb => gb.GuestId);

            //modelBuilder.Entity<GuestBooking>()
            //    .HasOne(gb => gb.Booking)
            //    .WithOne(b => b.Guest)
            //    .HasForeignKey( => );

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Guest)
                .WithMany(g => g.Bookings)
                .HasForeignKey(b => b.GuestId)
                .HasConstraintName("ForeignKey_Booking_Guest");

            //foreach (var relationship in modelbuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            //{
            //    relationship.DeleteBehavior = DeleteBehavior.Restrict;
            //}

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<SingleRoom> SingleRooms { get; set; }
        public DbSet<DoubleRoom> DoubleRooms { get; set; }
        public DbSet<Suite> Suites { get; set; }
    }
}
