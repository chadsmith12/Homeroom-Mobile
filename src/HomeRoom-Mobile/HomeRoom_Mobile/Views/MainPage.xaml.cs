using System;
using System.Collections.Generic;
using HomeRoom_Mobile.Interfaces;
using HomeRoom_Mobile.Models;
using HomeRoom_Mobile.Models.Api;
using HomeRoom_Mobile.ViewModels;
using Xamarin.Forms;

namespace HomeRoom_Mobile.Views
{
    public partial class MainPage : ContentPage
    {
        private MainViewModel Vm => BindingContext as MainViewModel;

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasBackButton(this, false);
        }

        private async void CourseTaped(object sender, ItemTappedEventArgs e)
        {
            var course = (CourseDto) e.Item;
            Vm.ViewCourseCommand.Execute(course);
            ((ListView) sender).SelectedItem = null;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // initialize the view model
            if (Vm != null)
                await Vm.Init();
        }

        private async void Refreshing(object sender, EventArgs e)
        {
            Vm.RefreshCoursesCommand.Execute(e);
        }
    }
}
