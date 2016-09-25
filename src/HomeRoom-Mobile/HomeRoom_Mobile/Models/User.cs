using System.Collections.Generic;
using HomeRoom_Mobile.Enumerations;
using SQLiteNetExtensions.Attributes;

namespace HomeRoom_Mobile.Models
{
    public class User : BaseObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public AccountType AccountType { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public virtual IList<SyncHistory> SyncHistories { get; set; }
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public virtual IList<Course> Courses { get; set; } 
    }
}
