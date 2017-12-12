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
        int UserId
        {
            get; set;
        }
        User User
        {
            get; set;
        }
    }
}