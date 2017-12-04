namespace BLL.Converters
{
    public interface IConverter <IEntity, IBusinessObject>
    {
        IEntity Convert(IBusinessObject businessObject);
        IBusinessObject Convert(IEntity entity);
    }
}
