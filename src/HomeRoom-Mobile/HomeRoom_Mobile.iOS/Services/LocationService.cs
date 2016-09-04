using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HomeRoom_Mobile.Interfaces;
using HomeRoom_Mobile.Models;
using Xamarin.Geolocation;

namespace HomeRoom_Mobile.iOS.Services
{
    /// <summary>
    /// Implements the location service for the iOS Platform
    /// </summary>
    /// <seealso cref="HomeRoom_Mobile.Interfaces.ILocationService" />
    public class LocationService : ILocationService
    {
        /// <summary>
        /// Gets the geo coordinates of the users current location asynchronously.
        /// Automatically sets the desired accuracy to 30 and timeout value to 30000
        /// </summary>
        /// <returns>
        /// Task - GeoCoords that were received
        /// </returns>
        public async Task<GeoCoords> GetGeoCoordinatesAsync()
        {
            return await GetGeoCoordinatesAsync(30, 30000);
        }

        /// <summary>
        /// Gets the geo coordinates of the users current location asynchronously.
        /// </summary>
        /// <param name="desiredAccuracy">The desired accuracy.</param>
        /// <param name="timeout">The timeout value</param>
        /// <returns></returns>
        public async Task<GeoCoords> GetGeoCoordinatesAsync(double desiredAccuracy, int timeout)
        {
            var locator = new Geolocator {DesiredAccuracy = desiredAccuracy};

            var position = await locator.GetPositionAsync(timeout);

            var result = new GeoCoords {Latitude = position.Latitude, Longitude = position.Longitude};
            return result;
        }
    }
}
