using DAL.Context;
using DAL.Entities;
using DAL.Repositories;

namespace DAL.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGuestRepository GuestRepository { get; internal set; }
<<<<<<< HEAD
        public IRepository<SingleRoom> SingleRepository { get; internal set; }
        public IDoubleRepository DoubleRepository { get; internal set; }
        public ISuiteRepository SuiteRepository { get; internal set; }
=======
        //public ISingleRepository SingleRepository { get; internal set; }
        //public IDoubleRepository DoubleRepository { get; internal set; }
        public SuiteRepository SuiteRepository { get; internal set; }
>>>>>>> master
        private HotelExamContext context;

        public UnitOfWork()
        {
            context = new HotelExamContext();
            context.Database.EnsureCreated();
            GuestRepository = new GuestRepository(context);
<<<<<<< HEAD
            SingleRepository = new SingleRoomRepository(context);
            DoubleRepository = new DoubleRepository(context);
=======
            //SingleRepository = new SingleRepository(context);
            //DoubleRepository = new DoubleRepository(context);
>>>>>>> master
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
