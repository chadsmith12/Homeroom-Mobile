using HomeRoom_Mobile.Modules;
using HomeRoom_Mobile.ViewModels;
using Ninject;
using Ninject.Modules;
using Xamarin.Forms;

namespace HomeRoom_Mobile
{
    public partial class App : Application
    {
        /// <summary>
        /// Gets or sets the kernal.
        /// </summary>
        /// <value>
        /// The kernal.
        /// </value>
        public IKernel Kernal { get; set; }


        public App(params INinjectModule[] platformModules)
        {
            InitializeComponent();
            var mainPage = new NavigationPage(new Views.MainPage());
            
            // Register all of our core services with the Kernal
            Kernal = new StandardKernel(new CoreModule(), new NavigationModule(mainPage.Navigation));
            // Register all of our plaform modules with the kernal
            Kernal.Load(platformModules);

            // Get the MainViewModel from the IoC
            mainPage.BindingContext = Kernal.Get<MainViewModel>();

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
