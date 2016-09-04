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

        }
    }
}
