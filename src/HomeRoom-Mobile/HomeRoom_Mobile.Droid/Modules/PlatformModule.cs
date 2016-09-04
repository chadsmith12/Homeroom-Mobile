using HomeRoom_Mobile.Droid.Services;
using HomeRoom_Mobile.Interfaces;
using Ninject.Modules;

namespace HomeRoom_Mobile.Droid.Modules
{
    public class PlatformModule : NinjectModule
    {
        /// <summary>
        /// Loads the Android platform specific services into the kernel.
        /// Use this method to bind all android platform specific services
        /// </summary>
        public override void Load()
        {
            // Bind Here
            Bind<ILocationService>().To<LocationService>().InSingletonScope();
        }
    }
}