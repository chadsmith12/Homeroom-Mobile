using System.Collections.Generic;
using System.Linq;
using HomeRoom_Mobile.Interfaces;
using HomeRoom_Mobile.Models;
using SQLite;
using Xamarin.Forms;

namespace HomeRoom_Mobile.Repository
{
    /// <summary>
    /// SQLite Generic Repository Class.
    /// Provides access to a sqlite database.
    /// To be good for memory on a mobile device, only one instance of this class should be made, though can be avoided if needed.
    /// </summary>
    public class Repository
    {
        private static readonly object Locker = new object();
        private readonly SQLiteConnection _database;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository"/> class.
        /// </summary>
        /// <param name="dbName">Name of the database.</param>
        public Repository(string dbName)
        {
            var currentApp = (App) Application.Current;
            // get the current database service we are using
            var dbService = (IDatabase) currentApp.Kernal.GetService(typeof (IDatabase));

            // make a connection the this database. If the database does not exist it will be created
            _database = dbService.DbConnect(dbName);

            // Define/Create any of the tables the database needs here
            _database.CreateTable<Course>();
            _database.CreateTable<User>();
            _database.CreateTable<SyncHistory>();
        }

        /// <summary>
        /// Gets all of the objects of type <typeparamref name="TObject"/>.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <returns></returns>
        public IEnumerable<TObject> GetAll<TObject>() where TObject : IBaseObject, new()
        {
            lock (Locker)
            {
                return _database.Table<TObject>().ToList();
            }
        }

        /// <summary>
        /// Gets the object by identifier.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public TObject GetById<TObject>(long id) where TObject : IBaseObject, new()
        {
            lock (Locker)
            {
                return _database.Table<TObject>().FirstOrDefault(x => x.Id == id);
            }
        }

        /// <summary>
        /// Gets the object by web identifier.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="webId">The web identifier.</param>
        /// <returns></returns>
        public TObject GetByWebId<TObject>(long webId) where TObject : IBaseObject, new()
        {
            lock (Locker)
            {
                return _database.Table<TObject>().FirstOrDefault(x => x.WebId == webId);
            }
        }

        /// <summary>
        /// Saves the specified object.
        /// If the objects primary key is 0 it preforms an insert.
        /// Otherwise it preforms an update on the object
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="obj">The object.</param>
        /// <returns>Primary key of the saved object</returns>
        public long Save<TObject>(TObject obj) where TObject : IBaseObject
        {
            lock (Locker)
            {
                if (obj.Id == 0)
                {
                    return _database.Insert(obj);
                }
                else
                {
                    _database.Update(obj);
                    return obj.Id;
                }
            }
        }

        /// <summary>
        /// Deletes the specified object by its identifier.
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        /// <param name="id">The identifier.</param>
        /// <returns>the identifer of the deleted object</returns>
        public long Delete<TObject>(int id) where TObject : IBaseObject, new()
        {
            lock (Locker)
            {
                return _database.Delete<TObject>(id);
            }
        }

        /// <summary>
        /// Deletes/drops the table of type <typeparamref name="TObject"/>.
        /// Recreates an empty table afterwards
        /// </summary>
        /// <typeparam name="TObject">The type of the object.</typeparam>
        public void DeleteAll<TObject>()
        {
            lock (Locker)
            {
                _database.DropTable<TObject>();
                _database.CreateTable<TObject>();
            }
        }
    }
}
