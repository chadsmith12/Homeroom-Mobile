﻿using System.Threading.Tasks;
using System.Windows.Input;
using HomeRoom_Mobile.Interfaces;
using HomeRoom_Mobile.Interfaces.DataService;
using HomeRoom_Mobile.Models.Api;
using PropertyChanged;
using Xamarin.Forms;

namespace HomeRoom_Mobile.ViewModels
{
    [ImplementPropertyChanged]
    public class SignInViewModel : BaseViewModel
    {
        #region Private Properties
        private readonly IDataService _dataService;
        private ICommand _signInCommand;
        #endregion

        #region Constructors
        public SignInViewModel(INavigationService navigationService, IDataService dataService) : base(navigationService)
        {
            _dataService = dataService;
        }
        #endregion

        #region Methods
        public override async Task Init()
        {
            await NavigationService.ClearBackStack();
        }

        private async Task ExecuteSignInCommand()
        {
            var userSignIn = new UserSignInDto
            {
                UsernameOrEmailAddress = Email,
                Password = Password,
                TenancyName = "Default"
            };
            var response = await _dataService.GetAuthTokenAsync(userSignIn);

            if (response.Success)
            {
                Helpers.Settings.ApiAuthToken = response.Result.ApiToken;
                Helpers.Settings.CurrentUserId = response.Result.UserId;
                Helpers.Settings.NeedsApiSync = true;
                await NavigationService.NavigateTo<MainViewModel>();
                await NavigationService.RemoveLastView();
            }
        }
        #endregion

        #region Properties
        public ICommand SignInCommand
        {
            get { return _signInCommand ?? (_signInCommand = new Command(async () => await ExecuteSignInCommand())); }
        }
        public string Email { get; set; }
        public string Password { get; set; }
        #endregion
    }
}
