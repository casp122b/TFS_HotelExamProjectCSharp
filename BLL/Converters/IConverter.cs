namespace BLL.Converters
{
    public interface IConverter<IEntity, IBusinessObject>
    {
        //Converts BusinessObject to Entity 
        IEntity Convert(IBusinessObject businessObject);
        //Converts Entity to BusinessObject 
        IBusinessObject Convert(IEntity entity);
    }
}