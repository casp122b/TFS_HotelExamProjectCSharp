using DAL.Context;
using DAL.Entities;
using DAL.Repositories;

namespace DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGuestRepository GuestRepository { get; internal set; }
        public IRepository<SingleRoom> SingleRoomRepository { get; internal set; }
        //public IDoubleRepository DoubleRepository { get; internal set; }
        public SuiteRepository SuiteRepository { get; internal set; }
        private HotelExamContext context;

        public UnitOfWork()
        {
            context = new HotelExamContext();
            context.Database.EnsureCreated();
            GuestRepository = new GuestRepository(context);
            SingleRoomRepository = new SingleRoomRepository(context);
            //DoubleRepository = new DoubleRepository(context);
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
