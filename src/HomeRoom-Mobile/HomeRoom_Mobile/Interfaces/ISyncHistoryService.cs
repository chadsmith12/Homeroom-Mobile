using System;
using System.Threading.Tasks;
using HomeRoom_Mobile.Models;

namespace HomeRoom_Mobile.Interfaces
{
    public interface ISyncHistoryService
    {
        /// <summary>
        /// Gets the latest synchronize date for the user.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        Task<DateTime?> GetLatestSyncDate(long userId);

        /// <summary>
        /// Inserts the synchronize history.
        /// </summary>
        /// <param name="history">The history.</param>
        /// <returns></returns>
        Task InsertSyncHistory(SyncHistory history);
    }
}
