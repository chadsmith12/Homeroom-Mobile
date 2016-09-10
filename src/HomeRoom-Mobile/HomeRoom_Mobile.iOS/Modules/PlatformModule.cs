using HomeRoom_Mobile.iOS.Services;
using HomeRoom_Mobile.Interfaces;
using Ninject.Modules;

namespace HomeRoom_Mobile.iOS.Modules
{
    public class PlatformModule : NinjectModule
    {
        /// <summary>
        /// Loads the iOS platform specific services into the kernel.
        /// Use this method to bind all iOS platform specific services
        /// </summary>
        public override void Load()
        {
            // Bind Here.
            Bind<ILocationService>().To<LocationService>().InSingletonScope();
            Bind<IDatabase>().To<Database>().InSingletonScope();
        }
    }
}
