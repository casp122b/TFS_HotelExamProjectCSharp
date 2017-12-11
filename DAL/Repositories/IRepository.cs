using System.Collections.Generic;

namespace DAL.Repositories
{
    public interface IRepository<IEntity>
    {
        //Create
        IEntity Create(IEntity ent);
        //Read
        IEnumerable<IEntity> GetAll();
        IEntity Get(int Id);
        //Delete
        IEntity Delete(int Id);
    }
}
