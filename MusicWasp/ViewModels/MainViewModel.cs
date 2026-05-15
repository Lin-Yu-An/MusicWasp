using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MusicWasp.Data;
using MusicWasp.Models;
using System.Collections.ObjectModel;
using MusicWasp.Services;

namespace MusicWasp.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly SongData _songData = new SongData();
        public ObservableCollection<Song> Songs { get; set; }

        [ObservableProperty]
        private Song? _selectedSong;

        [ObservableProperty]
        private ObservableObject currentViewModel;

        public MainViewModel()
        {
            var navigationService = new NavigationService();
            navigationService.CurrentViewModelChanged += vm => CurrentViewModel = vm;
            navigationService.NavigateTo("Home");

            Songs = SongManager.GetSongs();
            //Songs = new ObservableCollection<Song>(_songData.GetAllSongs());
        }

        [RelayCommand]
        private void AddSong()
        {
            Song newSong = new Song()
            {
                Title = "New Song",
                Duration = 300,
                PlayCount = 0
            };

            int id = _songData.InsertSong(newSong);
            newSong.SongID = id;
            Songs.Add(newSong);
        }

        [RelayCommand]
        private void DeleteSong()
        {
            if (SelectedSong != null)
            {
                _songData.DeleteSong(SelectedSong.SongID);
                Songs.Remove(SelectedSong);
            }
        }
    }
}

//namespace YourApp.ViewModels
//{
//    public partial class MainViewModel : ObservableObject
//    {
//        [ObservableProperty]
//        private ObservableObject currentViewModel;

//        public MainViewModel()
//        {
//            var navigationService = new NavigationService();
//            navigationService.CurrentViewModelChanged += vm => CurrentViewModel = vm;
//            navigationService.NavigateTo("Home"); // initial view shown when app starts
//        }
//    }
//}