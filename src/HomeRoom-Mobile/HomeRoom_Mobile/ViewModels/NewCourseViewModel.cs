using System;
using System.Threading.Tasks;
using HomeRoom_Mobile.Interfaces;
using HomeRoom_Mobile.Models;
using PropertyChanged;
using Xamarin.Forms;

namespace HomeRoom_Mobile.ViewModels
{
    [ImplementPropertyChanged]
    public class NewCourseViewModel : BaseViewModel
    {
        #region Constructors
        public NewCourseViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        #endregion

        #region Methods
        public override async Task Init()
        {
            Name = String.Empty;
        }
        /// <summary>
        /// Determines whether this instance can save.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance can save; otherwise, <c>false</c>.
        /// </returns>
        private bool CanSave()
        {
            return !string.IsNullOrWhiteSpace(this.Name);
        }

        /// <summary>
        /// Executes the save command.
        /// </summary>
        private async Task ExecuteSaveCommand()
        {
            var newCourse = new Course
            {
                Name = this.Name,
                Subject = this.Subject,
                Teacher = this.Teacher
            };

            // Todo: Implement logic to persist entry
            await NavigationService.GoBack();
        }

        #endregion

        #region Properties
        public string Name { get; set; }

        public string Subject { get; set; }

        public string Teacher { get; set; }

        // Commands
        public Command SaveCommand => new Command(async () => await ExecuteSaveCommand(), CanSave);
        #endregion
    }
}
