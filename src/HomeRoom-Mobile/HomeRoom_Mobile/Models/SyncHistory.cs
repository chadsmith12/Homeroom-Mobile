using System;
using SQLiteNetExtensions.Attributes;

namespace HomeRoom_Mobile.Models
{
    public class SyncHistory : BaseObject
    {
        [ForeignKey(typeof(User))]
        public long UserId { get; set; }
        public DateTime SyncDate { get; set; }

        [ManyToOne()]
        public User User { get; set; }

    }
}
