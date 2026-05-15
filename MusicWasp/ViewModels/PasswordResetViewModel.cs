using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicWasp.Services;

namespace MusicWasp.ViewModels
{
    public partial class PasswordResetViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        public PasswordResetViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        [RelayCommand]
        private void Navigate(string viewName)
        {
            _navigationService.NavigateTo(viewName);
        }
    }
}