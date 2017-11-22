using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Converters
{
    public interface IConverter <IEntity, IBusinessObject>
    {
        IEntity Convert(IBusinessObject businessObject);
        IBusinessObject Convert(IEntity entity);
    }
}
