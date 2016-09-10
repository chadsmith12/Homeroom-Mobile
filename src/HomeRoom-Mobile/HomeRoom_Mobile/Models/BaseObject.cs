using SQLite;

namespace HomeRoom_Mobile.Models
{
    /// <summary>
    /// Defines a base entity type. All entities should inherit from this
    /// </summary>
    public abstract class BaseObject : IBaseObject
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        [PrimaryKey][AutoIncrement]
        public virtual long Id { get; set; }

        /// <summary>
        /// Gets or sets the web identifier.
        /// </summary>
        /// <value>
        /// The web identifier.
        /// </value>
        public virtual long WebId { get; set; }
    }

}
