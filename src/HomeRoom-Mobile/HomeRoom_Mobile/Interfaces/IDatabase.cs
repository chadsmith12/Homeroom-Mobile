using SQLite;

namespace HomeRoom_Mobile.Interfaces
{
    /// <summary>
    /// Interface that all sqlite connections must implement
    /// Each platform specific database class must implement this interface
    /// </summary>
    public interface IDatabase
    {
        /// <summary>
        /// Connects to the database.
        /// </summary>
        /// <param name="dbName">Name of the database.</param>
        /// <returns></returns>
        SQLiteConnection DbConnect(string dbName);
    }
}
