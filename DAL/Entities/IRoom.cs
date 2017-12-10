namespace DAL.Entities
{
    public interface IRoom: IEntity
    {
        double Price
        {
            get; set;
        }
        int Available
        {
            get; set;
        }
        int GuestId
        {
            get; set;
        }
        Guest Guest
        {
            get; set;
        }
    }
}