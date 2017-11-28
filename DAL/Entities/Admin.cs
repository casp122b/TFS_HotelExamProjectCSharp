namespace DAL.Entities
{
    public class Admin : IPerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Id { get; set; }
    }
}
