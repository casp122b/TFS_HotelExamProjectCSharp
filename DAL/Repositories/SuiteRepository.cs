using DAL.Context;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories
{
    public class SuiteRepository: IRepository<Suite>
    {
        HotelExamContext context;

        public SuiteRepository(HotelExamContext context)
        {
            this.context = context;
        }

        public Suite Create(Suite suite)
        {
            context.Suites.Add(suite);
            return suite;
        }

        public Suite Delete(int Id)
        {
            var suite = Get(Id);
            if (suite != null)
            {
                context.Suites.Remove(suite);
            }

            return suite;
        }

        public Suite Get(int Id) => context.Suites.FirstOrDefault(s => s.Id == Id);

        public IEnumerable<Suite> GetAll() => context.Suites.ToList();
    }
}