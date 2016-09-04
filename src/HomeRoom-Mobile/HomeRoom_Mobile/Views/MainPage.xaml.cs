using System;
using System.Collections.Generic;
using HomeRoom_Mobile.Interfaces;
using HomeRoom_Mobile.Models;
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
        }

        private async void CourseTaped(object sender, ItemTappedEventArgs e)
        {
            var coure = (Course) e.Item;
            Vm.ViewCourseCommand.Execute(coure);
            ((ListView) sender).SelectedItem = null;
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // initialize the view model
            if (Vm != null)
                await Vm.Init();
        }
    }
}
