using System.Threading.Tasks;
using HomeRoom_Mobile.Interfaces;
using HomeRoom_Mobile.Models;
using PropertyChanged;

namespace HomeRoom_Mobile.ViewModels
{
    [ImplementPropertyChanged]
    public class CourseDetailViewModel : BaseViewModel<Course>
    {
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Teacher { get; set; }

        public CourseDetailViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public override async Task Init(Course course)
        {
            Name = course.Name;
            Subject = course.Subject;
            Teacher = course.Teacher;
        }
    }
}
