namespace DAL.Entities
{
    public interface IRoom: IEntity
    {
        string Name
        {
            get; set;
        }
        double Price
        {
            get; set;
        }
        bool Available
        {
            get; set;
        }
        int? GuestId
        {
            get; set;
        }
        Guest Guest
        {
            get; set;
        }
    }
}