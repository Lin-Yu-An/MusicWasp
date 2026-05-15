using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicWasp.Services;

namespace MusicWasp.ViewModels
{
    public partial class CreateAccountViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        public CreateAccountViewModel(INavigationService navigationService)
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