﻿using System.Dynamic;
using HomeRoom_Mobile.Modules;
using HomeRoom_Mobile.ViewModels;
using Ninject;
using Ninject.Modules;
using Xamarin.Forms;

namespace HomeRoom_Mobile
{
    public partial class App : Application
    {
        private static Repository.Repository _repository;

        /// <summary>
        /// Gets or sets the kernal.
        /// </summary>
        /// <value>
        /// The kernal.
        /// </value>
        public IKernel Kernal { get; set; }

        /// <summary>
        /// Gets the repository.
        /// If there isn't a repository yet then it creates a new one with the specified database name
        /// </summary>
        /// <value>
        /// The repository.
        /// </value>
        public static Repository.Repository Repository => _repository ?? (_repository = new Repository.Repository("HomeRoom-Mobile.db3"));

        /// <summary>
        /// Gets a value indicating whether the user is signed in.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is signed in; otherwise, <c>false</c>.
        /// </value>
        public bool IsSignedIn => !string.IsNullOrWhiteSpace(Helpers.Settings.ApiAuthToken);

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
