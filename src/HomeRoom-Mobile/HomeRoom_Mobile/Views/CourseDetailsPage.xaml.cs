using HomeRoom_Mobile.Interfaces;
using HomeRoom_Mobile.Models;
using HomeRoom_Mobile.ViewModels;
using Xamarin.Forms;

namespace HomeRoom_Mobile.Views
{
    public partial class CourseDetailsPage : ContentPage
    {
        public CourseDetailsPage()
        {
            InitializeComponent();
            BindingContext = new CourseDetailViewModel(DependencyService.Get<INavigationService>());
        }
    }
}
