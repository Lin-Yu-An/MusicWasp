using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicWasp.Services;
using MusicWasp.Models;
using MusicWasp.Data;

namespace MusicWasp.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        //private readonly UserData _userData = new UserData();

        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string errorMessage;

        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        [RelayCommand]
        private void Navigate(string viewName)
        {
            _navigationService.NavigateTo(viewName);
        }

        [RelayCommand]
        private void Login()
        {
            //ErrorMessage = string.Empty;

            //var user = _userData.Authenticate(Username, Password);
            //if (user == null)
            //{
            //    ErrorMessage = "Invalid username or password.";
            //    return;
            //}

            //// Store the logged-in user globally
            //CurrentUser.User = user;

            // Try to find a matching user
            User? user = User.Login(Username, Password);

            if (user == null)
            {
                ErrorMessage = "Wrong username or password.";
                return;
            }

            // Remember who's logged in
            CurrentUser.LoggedInUser = user;
            _navigationService.NavigateTo("MainApp");
        }
    }
}