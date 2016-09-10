using System;
using System.IO;
using HomeRoom_Mobile.Interfaces;
using SQLite;

namespace HomeRoom_Mobile.iOS.Services
{
    /// <summary>
    /// Implements the SQLite Database connection for iOS.
    /// </summary>
    /// <seealso cref="HomeRoom_Mobile.Interfaces.IDatabase" />
    public class Database : IDatabase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Database"/> class.
        /// </summary>
        public Database() { }

        /// <summary>
        /// Connects to the SQLite Database on iOS.
        /// </summary>
        /// <param name="dbName">Name of the database.</param>
        /// <returns></returns>
        public SQLiteConnection DbConnect(string dbName)
        {
            var folder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryFolder = Path.Combine(folder, "..", "Library");
            var path = Path.Combine(libraryFolder, dbName);
            return new SQLiteConnection(path);
        }
    }
}
