using HomeRoom_Mobile.Interfaces;
using HomeRoom_Mobile.Services;
using HomeRoom_Mobile.ViewModels;
using HomeRoom_Mobile.Views;
using Ninject.Modules;
using Xamarin.Forms;

namespace HomeRoom_Mobile.Modules
{
    public class NavigationModule : NinjectModule
    {
        #region Private Fields

        private readonly INavigation _formsNavigation;
        #endregion

        #region Constructors
        public NavigationModule(INavigation formsNavigation)
        {
            _formsNavigation = formsNavigation;
        }
        #endregion

        /// <summary>
        /// Loads/registers the navigation mappings into the kernel.
        /// </summary>
        public override void Load()
        {
            // make the navigation service to register the view model to view mappings
            var navigationService = new NavigationService {XamarinNavigation = _formsNavigation};

            // Register View Mappings
            navigationService.RegisterViewMapping(typeof(CourseDetailViewModel), typeof(CourseDetailsPage));
            navigationService.RegisterViewMapping(typeof(MainViewModel), typeof(MainPage));
            navigationService.RegisterViewMapping(typeof(NewCourseViewModel), typeof(NewCoursePage));
            navigationService.RegisterViewMapping(typeof(SignInViewModel), typeof(SignInPage));
            
            // Bind the Navigation service
            Bind<INavigationService>().ToMethod(x => navigationService).InSingletonScope();
        }
    }
}
