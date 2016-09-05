using System;
using HomeRoom_Mobile.Interfaces.DataService;
using HomeRoom_Mobile.Services.DataService;
using HomeRoom_Mobile.ViewModels;
using Ninject.Modules;

namespace HomeRoom_Mobile.Modules
{
    public class CoreModule : NinjectModule
    {
        /// <summary>
        /// Loads the core services into the kernel.
        /// Use this method to bind all view models and core services
        /// </summary>
        public override void Load()
        {
            // Bind ViewModels
            Bind<CourseDetailViewModel>().ToSelf();
            Bind<MainViewModel>().ToSelf();
            Bind<NewCourseViewModel>().ToSelf();

            // Bind Core Services
            var dataService = new DataService(new Uri("http://homeroomdev.azurewebsites.net"));

            Bind<IDataService>().ToMethod(x => dataService);

        }
    }
}
