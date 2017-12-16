using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public interface IGuestRepository<Guest>
    {
        //Create
        Guest Create(Guest ent);
        //Read
        IEnumerable<Guest> GetAll();
        Guest Get(int? Id);
        //Delete
        Guest Delete(int Id);
    }
}
