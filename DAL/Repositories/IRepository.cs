using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public interface IRepository<IEntity>
    {
        //Create
        IEntity Create(IEntity ent);
        //Read
        IEnumerable<IEntity> GetAll();
        IEntity Get(int Id);
        IEnumerable<IEntity> GetAllById(List<int> ids);
        //Delete
        IEntity Delete(int Id);
    }
}
