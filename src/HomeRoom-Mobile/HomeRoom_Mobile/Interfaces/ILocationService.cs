using System.Threading.Tasks;
using HomeRoom_Mobile.Models;

namespace HomeRoom_Mobile.Interfaces
{
    /// <summary>
    /// Provides the methods needed when using location services in an app
    /// </summary>
    public interface ILocationService
    {
        /// <summary>
        /// Gets the geo coordinates of the users current location asynchronously.
        /// </summary>
        /// <returns>Task - GeoCoords that were received</returns>
        Task<GeoCoords> GetGeoCoordinatesAsync();

        /// <summary>
        /// Gets the geo coordinates of the users current location asynchronously.
        /// </summary>
        /// <param name="desiredAccuracy">The desired accuracy.</param>
        /// <param name="timeout">The timeout value</param>
        /// <returns></returns>
        Task<GeoCoords> GetGeoCoordinatesAsync(double desiredAccuracy, int timeout);
    }
}
