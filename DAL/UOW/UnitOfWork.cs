using DAL.Context;
using DAL.Entities;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using System;

namespace DAL.UOW
{
    public class UnitOfWork: IUnitOfWork
    {
        public IRepository<Guest> GuestRepository
        {
            get; internal set;
        }
        public IRepository<Admin> AdminRepository
        {
            get; internal set;
        }
        public IRepository<User> UserRepository
        {
            get; internal set;
        }
        public IRepository<Booking> BookingRepository
        {
            get; internal set;
        }
        public IRepository<SingleRoom> SingleRoomRepository
        {
            get; internal set;
        }
        public IRepository<DoubleRoom> DoubleRoomRepository
        {
            get; internal set;
        }
        public IRepository<Suite> SuiteRepository
        {
            get; internal set;
        }
        HotelExamContext context;

        public UnitOfWork(DbOptions opt)
        {
            DbContextOptions<HotelExamContext> options;
            Console.WriteLine(opt.Environment);

            // Connects to our in memory database
            if (opt.Environment == "Development")
            {
                options = new DbContextOptionsBuilder<HotelExamContext>()
                   .UseInMemoryDatabase("InternalDb")
                   .Options;
            }
            // Connects to our actual database
            else
            {
                options = new DbContextOptionsBuilder<HotelExamContext>()
                .UseSqlServer(opt.ConnectionString)
                    .Options;
            }

            // Ensures that the database exsists
            context = new HotelExamContext(options);
            context.Database.EnsureCreated();
            GuestRepository = new GuestRepository(context);
            AdminRepository = new AdminRepository(context);
            UserRepository = new UserRepository(context);
            BookingRepository = new BookingRepository(context);
            SingleRoomRepository = new SingleRoomRepository(context);
            DoubleRoomRepository = new DoubleRoomRepository(context);
            SuiteRepository = new SuiteRepository(context);
        }

        // Savechanges represents the number of of objects  written to the underlying database
        public int Complete() => context.SaveChanges();

        // Dispose context when it is done
        public void Dispose() => context.Dispose();
    }
}