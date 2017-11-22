using DAL.Context;
using DAL.Repositories;

namespace DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRoomRepository RoomRepository { get; internal set; }
        public IGuestRepository GuestRepository { get; internal set; }
        private HotelExamContext context;

        public UnitOfWork()
        {
            context = new HotelExamContext();
            context.Database.EnsureCreated();
            RoomRepository = new RoomRepository(context);
            GuestRepository = new GuestRepository(context);
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
