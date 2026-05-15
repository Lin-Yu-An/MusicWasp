using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicWasp.Services;
using MusicWasp.Models;

namespace MusicWasp.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        //public string WelcomeMessage =>
        //    CurrentUser.IsLoggedIn
        //        ? $"Welcome, {CurrentUser.User!.Username}!"
        //        : "Welcome to MusicWasp";

        //public bool IsLoggedIn => CurrentUser.IsLoggedIn;
        //public bool IsAdmin => CurrentUser.IsAdmin;

        public string WelcomeMessage { get; }
        public bool IsLoggedIn { get; }
        public bool IsAdmin { get; }

        public HomeViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            // Set values based on who is logged in
            if (CurrentUser.IsLoggedIn)
            {
                WelcomeMessage = "Welcome, " + CurrentUser.LoggedInUser!.Username + "!";
                IsLoggedIn = true;
                IsAdmin = CurrentUser.IsAdmin;
            }
            else
            {
                WelcomeMessage = "Welcome to MusicWasp";
                IsLoggedIn = false;
                IsAdmin = false;
            }
        }

        [RelayCommand]
        private void Navigate(string viewName)
        {
            _navigationService.NavigateTo(viewName);
        }

        [RelayCommand]
        private void Logout()
        {
            //CurrentUser.User = null;
            CurrentUser.LoggedInUser = null;
            _navigationService.NavigateTo("Home");
        }
    }
}