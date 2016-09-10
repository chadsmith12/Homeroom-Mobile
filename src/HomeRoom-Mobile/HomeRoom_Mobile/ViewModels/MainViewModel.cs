using System.Collections.ObjectModel;
using System.Threading.Tasks;
using HomeRoom_Mobile.Interfaces;
using HomeRoom_Mobile.Interfaces.DataService;
using HomeRoom_Mobile.Models.Api;
using PropertyChanged;
using Xamarin.Forms;

namespace HomeRoom_Mobile.ViewModels
{
    [ImplementPropertyChanged]
    public class MainViewModel : BaseViewModel
    {
        #region Privae Fields
        private readonly IDataService _dataService;
        #endregion

        #region Constructors
        public MainViewModel(INavigationService navigationService, IDataService dataService) : base(navigationService)
        {
            Courses = new ObservableCollection<CourseDto>();
            _dataService = dataService;
        }
        #endregion

        #region Methods
        public override async Task Init()
        {
            // send the user to the sign in page if the token is no longer valid
            var currentApp = (App)Application.Current;
            if (!currentApp.IsSignedIn)
                await NavigationService.NavigateTo<SignInViewModel>();

            await LoadCourses();
        }

        private async Task LoadCourses()
        {
            // if we are already busy just return from this method, don't try to load the courses twice
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var courses = await _dataService.GetAllCourses();

                if (courses.Success)
                    Courses = new ObservableCollection<CourseDto>(courses.Result.Courses);
            }
            finally
            {
                IsBusy = false;
            }
        }
        #endregion

        #region Properties
        public ObservableCollection<CourseDto> Courses { get; set; }

        public Command<CourseDto> ViewCourseCommand
        {
            get
            {
                return new Command<CourseDto>(async (course) =>
                {
                    await NavigationService.NavigateTo<CourseDetailViewModel, CourseDto>(course);
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
                    IsRefreshing = false;
                });
            }
        }

        #endregion
    }
}
