using System;
using System.Threading.Tasks;
using HomeRoom_Mobile.Interfaces;
using HomeRoom_Mobile.Models;
using HomeRoom_Mobile.Models.Api;
using PropertyChanged;

namespace HomeRoom_Mobile.ViewModels
{
    [ImplementPropertyChanged]
    public class CourseDetailViewModel : BaseViewModel<CourseDto>
    {
        public CourseDto Course { get; set; }

        public CourseDetailViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public override async Task Init(CourseDto course)
        {
            Course = course;
        }

        public override async Task Init()
        {
            await Task.Run(() =>
            {
                throw new Exception("Init was called without a valid course object");
            });

        }
    }
}
