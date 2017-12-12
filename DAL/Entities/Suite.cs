namespace DAL.Entities
{
    public class Suite: IRoom
    {
        public int Id
        {
            get; set;
        }
        public double Price
        {
            get; set;
        }
        public int Available
        {
            get; set;
        }
        public int UserId
        {
            get; set;
        }
        public User User
        {
            get; set;
        }
    }
}