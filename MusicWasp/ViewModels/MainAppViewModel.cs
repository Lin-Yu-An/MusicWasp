using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicWasp.Models;
using MusicWasp.Services;
using System.Collections.ObjectModel;

namespace MusicWasp.ViewModels
{
    public partial class MainAppViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;

        // Top bar info
        public string Username { get; }

        // Search bar
        [ObservableProperty]
        private string searchText = "";

        // Left sidebar - saved albums
        public ObservableCollection<string> SavedAlbums { get; }

        // Right sidebar - now playing queue
        public ObservableCollection<string> NowPlayingQueue { get; }

        // Currently playing song info (bottom bar)
        [ObservableProperty]
        private string currentSongTitle = "No song playing";

        [ObservableProperty]
        private bool isPlaying = false;

        public MainAppViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            // Get logged-in user name
            Username = CurrentUser.IsLoggedIn
                ? CurrentUser.LoggedInUser!.Username
                : "Guest";

            // Fill with placeholder data for now
            SavedAlbums = new ObservableCollection<string>
            {
                "Album Title 1",
                "Album Title 2",
                "Album Title 3"
            };

            NowPlayingQueue = new ObservableCollection<string>
            {
                "Song Title - Artist",
                "Song Title - Artist",
                "Song Title - Artist",
                "Song Title - Artist",
                "Song Title - Artist"
            };
        }

        [RelayCommand]
        private void Navigate(string viewName)
        {
            _navigationService.NavigateTo(viewName);
        }

        [RelayCommand]
        private void Search()
        {
            // TODO: search logic later
            System.Diagnostics.Debug.WriteLine($"Searching for: {SearchText}");
        }

        [RelayCommand]
        private void PlayPause()
        {
            IsPlaying = !IsPlaying;
        }

        [RelayCommand]
        private void Previous()
        {
            // TODO: previous song
        }

        [RelayCommand]
        private void Next()
        {
            // TODO: next song
        }

        [RelayCommand]
        private void Logout()
        {
            CurrentUser.LoggedInUser = null;
            _navigationService.NavigateTo("Home");
        }
    }
}
