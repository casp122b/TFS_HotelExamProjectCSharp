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

        //Makes the context available in the class
        public SuiteRepository(HotelExamContext context)
        {
            this.context = context;
        }

        //Add a suite to the context
        public Suite Create(Suite suite)
        {
            context.Suites.Add(suite);
            return suite;
        }

        //Remove a suite from the context by it's id if it exists
        public Suite Delete(int Id)
        {
            var suite = Get(Id);
            if (suite != null)
            {
                context.Suites.Remove(suite);
            }

            return suite;
        }

        //Get a suite from the context by it's id
        public Suite Get(int Id) => context.Suites.FirstOrDefault(s => s.Id == Id);

        //Get all suites from the context as a list
        public IEnumerable<Suite> GetAll() => context.Suites.ToList();
    }
}