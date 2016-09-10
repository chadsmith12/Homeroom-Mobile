using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using HomeRoom_Mobile.Interfaces;
using HomeRoom_Mobile.Interfaces.DataService;
using HomeRoom_Mobile.Models;
using PropertyChanged;
using Xamarin.Forms;

namespace HomeRoom_Mobile.ViewModels
{
    [ImplementPropertyChanged]
    public class MainViewModel : BaseViewModel
    {
        private readonly IDataService _dataService;
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

        public Command RefreshCoursesCommand
        {
            get
            {
                return new Command( async () =>
                {
                    if (IsRefreshing) return;
                    IsRefreshing = true;
                    await LoadCourses();
                    Debug.WriteLine("Finished refreshing...");
                    IsRefreshing = false;
                });
            }
        }

        public MainViewModel(INavigationService navigationService, IDataService dataService) : base(navigationService)
        {
            Courses = new ObservableCollection<Course>();
            _dataService = dataService;
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

            try
            {
                Debug.WriteLine("loading courses...");
                var courses = await _dataService.GetAllCourses();
                if (courses.Success)
                    Courses = new ObservableCollection<Course>(courses.Result.Courses.Select(x => new Course {Name = x.Name, Subject = x.Subject, Teacher = x.Teacher}));
                    
            }
            finally
            {
                IsBusy = false;
            }

        }
        #endregion
    }
}
