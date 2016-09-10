using System.IO;
using HomeRoom_Mobile.Interfaces;
using SQLite;
using Environment = System.Environment;

namespace HomeRoom_Mobile.Droid.Services
{
    /// <summary>
    /// Implements the SQLite Database connection for Android.
    /// </summary>
    /// <seealso cref="HomeRoom_Mobile.Interfaces.IDatabase" />
    public class Database : IDatabase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Database"/> class.
        /// </summary>
        public Database() { }

        /// <summary>
        /// Connects to the SQLite Database on Android.
        /// </summary>
        /// <param name="dbName">Name of the database.</param>
        /// <returns></returns>
        public SQLiteConnection DbConnect(string dbName)
        {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(folder, dbName);

            return new SQLiteConnection(path);
        }
    }
}