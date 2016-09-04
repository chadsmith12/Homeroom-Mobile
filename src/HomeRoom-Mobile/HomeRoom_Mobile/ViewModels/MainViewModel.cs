using System.Collections.ObjectModel;
using System.Threading.Tasks;
using HomeRoom_Mobile.Interfaces;
using HomeRoom_Mobile.Models;
using PropertyChanged;
using Xamarin.Forms;

namespace HomeRoom_Mobile.ViewModels
{
    [ImplementPropertyChanged]
    public class MainViewModel : BaseViewModel
    {
        public ObservableCollection<Course> Courses { get; set; }

        public Command<Course> ViewCourseCommand
        {
            get
            {
                return new Command<Course>(async (course) =>
                {
                    await NavigationService.NavigateTo<CourseDetailViewModel, Course>(course);
                });
            } 
            
        }

        public Command NewCourseCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await NavigationService.NavigateTo<NewCourseViewModel>();
                });
            }
        }

        public MainViewModel(INavigationService navigationService) : base(navigationService)
        {
            Courses = new ObservableCollection<Course>();
        }

        public override async Task Init()
        {
            await LoadCourses();
        }


        #region Private Methods

        private async Task LoadCourses()
        {
            // if we are already busy just return from this method, don't try to load the courses twice
            if (IsBusy)
                return;

            IsBusy = true;
            Courses.Clear();

            await Task.Delay(3000);

            await Task.Factory.StartNew(() =>
            {
                Courses.Add(new Course
                {
                    Name = "Math 101",
                    Subject = "Math",
                    Teacher = "Mrs. Smith"
                });
                Courses.Add(new Course
                {
                    Name = "English 101",
                    Subject = "English",
                    Teacher = "Mr. Joe"
                });
                Courses.Add(new Course
                {
                    Name = "History 101",
                    Subject = "History",
                    Teacher = "Mrs. Price"
                });
            });

            IsBusy = false;
        }
        #endregion
    }
}
