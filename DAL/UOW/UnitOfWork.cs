using DAL.Context;
using DAL.Repositories;

namespace DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public GuestRepository GuestRepository { get; internal set; }
        public AdminRepository AdminRepository { get; internal set; }
        public BookingRepository BookingRepository { get; internal set; }
        public SingleRoomRepository SingleRoomRepository { get; internal set; }
        public DoubleRoomRepository DoubleRoomRepository { get; internal set; }
        public SuiteRepository SuiteRepository { get; internal set; }
        private HotelExamContext context;

        public UnitOfWork()
        {
            context = new HotelExamContext();
            context.Database.EnsureCreated();
            GuestRepository = new GuestRepository(context);
            AdminRepository = new AdminRepository(context);
            BookingRepository = new BookingRepository(context);
            SingleRoomRepository = new SingleRoomRepository(context);
            DoubleRoomRepository = new DoubleRoomRepository(context);
            SuiteRepository = new SuiteRepository(context);
        }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
