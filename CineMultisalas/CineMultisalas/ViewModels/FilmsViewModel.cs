using CineMultisalas.Models;
using CineMultisalas.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;

namespace CineMultisalas.ViewModels
{
    internal class FilmsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Film> _films;
        public ObservableCollection<Film> Films
        {
            get => _films;
            set
            {
                _films = value;
                OnPropertyChanged(nameof(Films));
            }
        }

        public FilmsViewModel()
        {
            LoadFilms();
        }

        private async void LoadFilms()
        {
            // Carga películas desde DatabaseService
            var databaseService = new DatabaseService("YourConnectionString");
            var films = await databaseService.GetFilmsAsync();
            Films = new ObservableCollection<Film>(films);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}