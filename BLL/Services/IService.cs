using System.Collections.Generic;

namespace BLL.Services
{
    public interface IService<IBusinessObject>
    {
        //Create
        IBusinessObject Create(IBusinessObject bo);
        //Read
        List<IBusinessObject> GetAll();
        IBusinessObject Get(int Id);
        //Update
        IBusinessObject Update(IBusinessObject bo);
        //Delete
        IBusinessObject Delete(int Id);
    }
}
