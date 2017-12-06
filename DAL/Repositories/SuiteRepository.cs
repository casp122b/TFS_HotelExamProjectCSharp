using DAL.Context;
using DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class SuiteRepository : IRepository<Suite>
    {
        HotelExamContext _context;

        public SuiteRepository(HotelExamContext context)
        {
            _context = context;
        }

        public Suite Create(Suite suite)
        {
            _context.Suites.Add(suite);
            return suite;
        }

        public Suite Delete(int Id)
        {
            var suite = Get(Id);
            if (suite != null)
            {
                _context.Suites.Remove(suite);
            }
            return suite;
        }

        public Suite Get(int Id)
        {
            return _context.Suites.FirstOrDefault(s => s.Id == Id);
        }

        public IEnumerable<Suite> GetAll()
        {
            return _context.Suites.ToList();
        }
    }
}
