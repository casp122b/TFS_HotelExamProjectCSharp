using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class User: IEntity
    {
        [Key]
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
        public Guest Guest
        {
            get; set;
        }
        public Admin Admin
        {
            get; set;
        }
    }
}