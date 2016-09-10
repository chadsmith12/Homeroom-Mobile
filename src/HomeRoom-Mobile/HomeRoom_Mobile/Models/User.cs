using HomeRoom_Mobile.Enumerations;

namespace HomeRoom_Mobile.Models
{
    public class User : BaseObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public AccountType AccountType { get; set; }
    }
}
