using System.Collections.Generic;

namespace BLL.Services
{
    public interface IService<IBusinessObject>
    {
        //Create a BusinessObject
        IBusinessObject Create(IBusinessObject bo);
        //Get all businessObjects
        List<IBusinessObject> GetAll();
        //Get a businessObject by it's id
        IBusinessObject Get(int Id);
        //Update businessObject
        IBusinessObject Update(IBusinessObject bo);
        //Delete a businessObject by it's id
        IBusinessObject Delete(int Id);
    }
}
