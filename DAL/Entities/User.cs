using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [NotMapped]
        public string Password
        {
            get; set;
        }
        public byte[] PasswordHash
        {
            get; set;
        }
        public byte[] PasswordSalt
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