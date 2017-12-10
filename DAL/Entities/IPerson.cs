namespace DAL.Entities
{
    public interface IPerson: IEntity
    {
        string FirstName
        {
            get; set;
        }
        string LastName
        {
            get; set;
        }
        string Address
        {
            get; set;
        }
    }
}