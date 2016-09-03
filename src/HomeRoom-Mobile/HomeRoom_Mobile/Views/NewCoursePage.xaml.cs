using System;
using HomeRoom_Mobile.Interfaces;
using HomeRoom_Mobile.ViewModels;
using Xamarin.Forms;

namespace HomeRoom_Mobile.Views
{
    public partial class NewCoursePage : ContentPage
    {
        public NewCoursePage()
        {
            InitializeComponent();
            BindingContext = new NewCourseViewModel(DependencyService.Get<INavigationService>());
        }

        private void SaveCourseClicked(object sender, EventArgs e)
        {
            return;
        }
    }
}
