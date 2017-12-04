using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public interface IBookingRepository : IRepository<Booking>
    {
        IEnumerable<Booking> GetAllById(List<int> ids);
    }
}
