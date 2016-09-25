using SQLiteNetExtensions.Attributes;

namespace HomeRoom_Mobile.Models
{
    public class Course : BaseObject
    {
        public string Name { get; set; }

        public string Subject { get; set; }

        public string Teacher { get; set; }

        [ForeignKey(typeof(User))]
        public long UserId { get; set; }
        [ManyToOne()]
        public User User { get; set; }
    }
}
