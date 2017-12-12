namespace DAL.Entities
{
    public class User: IEntity
    {
        public int Id
        {
            get; set;
        }
        public string Username
        {
            get; set;
        }
        public string Password
        {
            get; set;
        }
        public string Role
        {
            get; set;
        }
        public int GuestId
        {
            get; set;
        }
        public Guest Guest
        {
            get; set;
        }
    }
}