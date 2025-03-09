using CineMultisalas.Models;
using CineMultisalas.Services;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CineMultisalas.ViewModels
{
    public class FilmsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Film> _films;
        private readonly FirebaseService _firebaseService;

        public ObservableCollection<Film> Films
        {
            get => _films;
            set
            {
                _films = value;
                OnPropertyChanged(nameof(Films));
            }
        }

        public ICommand AddFilmCommand { get; }
        public ICommand EditFilmCommand { get; }
        public ICommand DeleteFilmCommand { get; }

        public FilmsViewModel()
        {
            _firebaseService = new FirebaseService();
            LoadFilms();

            AddFilmCommand = new RelayCommand(OnAddFilm);
            EditFilmCommand = new RelayCommand(OnEditFilm);
            DeleteFilmCommand = new RelayCommand(OnDeleteFilm);
        }

        private async void LoadFilms()
        {
            var films = await _firebaseService.GetDataAsync<Film>("films");
            Films = new ObservableCollection<Film>(films);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async void OnAddFilm()
        {
            var newFilm = new Film
            {
                FilmId = Films.Count + 1, // Genera un ID único
                Title = "Nueva Película", 
                Description = "Descripción de la película", 
                Duration = 120, 
                Genre = "Acción" 
            };

            await _firebaseService.AddDataAsync("films", newFilm);
            LoadFilms(); 
        }

        private async void OnEditFilm()
        {
            if (Films.Count > 0)
            {
                var filmToEdit = Films[0]; // Selecciona la primera película (puedes usar un selector)
                filmToEdit.Title = "Película Editada"; // Nuevo título
                filmToEdit.Duration = 150; // Nueva duración

                await _firebaseService.UpdateDataAsync("films", filmToEdit.FilmId.ToString(), filmToEdit);
                LoadFilms(); // Recargar la lista de películas
            }
        }

        private async void OnDeleteFilm()
        {
            if (Films.Count > 0)
            {
                var filmToDelete = Films[0]; // Selecciona la primera película (puedes usar un selector)
                await _firebaseService.DeleteDataAsync("films", filmToDelete.FilmId.ToString());
                LoadFilms(); // Recargar la lista de películas
            }
        }

        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}