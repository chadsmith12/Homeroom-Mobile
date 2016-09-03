using HomeRoom_Mobile.Interfaces;
using HomeRoom_Mobile.Services;
using HomeRoom_Mobile.ViewModels;
using Xamarin.Forms;

namespace HomeRoom_Mobile
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var mainPage = new NavigationPage(new Views.MainPage());
            var navigationService = DependencyService.Get<INavigationService>() as NavigationService;
            navigationService.XamarinNavigation = mainPage.Navigation;

            // register the view model to view mappings
            navigationService.RegisterViewMapping(typeof(MainViewModel), typeof(Views.MainPage));
            navigationService.RegisterViewMapping(typeof(CourseDetailViewModel), typeof(Views.CourseDetailsPage));
            navigationService.RegisterViewMapping(typeof(NewCourseViewModel), typeof(Views.NewCoursePage));

            MainPage = mainPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
