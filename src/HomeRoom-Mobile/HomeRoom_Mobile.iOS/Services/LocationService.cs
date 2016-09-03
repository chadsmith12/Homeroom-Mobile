using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HomeRoom_Mobile.Interfaces;
using HomeRoom_Mobile.Models;
using Xamarin.Geolocation;

namespace HomeRoom_Mobile.iOS.Services
{
    public class LocationService : ILocationService
    {
        public async Task<GeoCoords> GetGeoCoordinatesAsync()
        {
            return await GetGeoCoordinatesAsync(30, 30000);
        }

        public async Task<GeoCoords> GetGeoCoordinatesAsync(double desiredAccuracy, int timeout)
        {
            var locator = new Geolocator {DesiredAccuracy = desiredAccuracy};

            var position = await locator.GetPositionAsync(timeout);

            var result = new GeoCoords {Latitude = position.Latitude, Longitude = position.Longitude};
            return result;
        }
    }
}
