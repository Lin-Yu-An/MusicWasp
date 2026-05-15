using System;
using CommunityToolkit.Mvvm.ComponentModel;
using MusicWasp.ViewModels;

namespace MusicWasp.Services
{
    public interface INavigationService
    {
        void NavigateTo(string viewName);
        event Action<ObservableObject> CurrentViewModelChanged;
    }

    public class NavigationService : INavigationService
    {
        public event Action<ObservableObject> CurrentViewModelChanged;

        public void NavigateTo(string viewName)
        {
            ObservableObject viewModel = viewName switch
            {
                "Home" => new HomeViewModel(this),
                "Login" => new LoginViewModel(this),
                "PasswordReset" => new PasswordResetViewModel(this),
                "CreateAccount" => new CreateAccountViewModel(this),
                "Settings" => new SettingsViewModel(this),
                "MainApp" => new MainAppViewModel(this),
                _ => throw new ArgumentException($"Unknown view: {viewName}")
            };

            CurrentViewModelChanged?.Invoke(viewModel);
        }
    }
}