using CineMultisalas.Models;
using CineMultisalas.Services;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace CineMultisalas.ViewModels
{
    internal class CinemasViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Cinema> _cinemas;
        private readonly FirebaseService _firebaseService;

        public ObservableCollection<Cinema> Cinemas
        {
            get => _cinemas;
            set
            {
                _cinemas = value;
                OnPropertyChanged(nameof(Cinemas));
            }
        }

        public ICommand AddCinemaCommand { get; }
        public ICommand EditCinemaCommand { get; }
        public ICommand DeleteCinemaCommand { get; }

        public CinemasViewModel()
        {
            _firebaseService = new FirebaseService();
            LoadCinemas();
            AddCinemaCommand = new RelayCommand(OnAddCinema);
            EditCinemaCommand = new RelayCommand(OnEditCinema);
            DeleteCinemaCommand = new RelayCommand(OnDeleteCinema);
        }

        private async void LoadCinemas()
        {
            // Cargar salas desde Firebase
            var cinemas = await _firebaseService.GetDataAsync<Cinema>("cinemas");
            Cinemas = new ObservableCollection<Cinema>(cinemas);
        }

        // Método que añade una nueva sala.
        private async void OnAddCinema()
        {
            var newCinema = new Cinema
            {
                CinemaId = Cinemas.Count + 1, // Generar un ID único
                Name = "Nueva Sala", // Nombre de la sala
                Capacity = 100 // Capacidad de la sala
            };

            await _firebaseService.AddDataAsync("cinemas", newCinema);
            LoadCinemas(); // Recargar la lista de salas
        }

        // Método que edita una sala existente.
        private async void OnEditCinema()
        {
            if (Cinemas.Count > 0)
            {
                var cinemaToEdit = Cinemas[0]; // Selecciona la primera sala (puedes usar un selector)
                cinemaToEdit.Name = "Sala Editada"; // Nuevo nombre
                cinemaToEdit.Capacity = 120; // Nueva capacidad

                await _firebaseService.UpdateDataAsync("cinemas", cinemaToEdit.CinemaId, cinemaToEdit);
                LoadCinemas(); // Recargar la lista de salas
            }
        }

        // Método que elimina una sala.
        private async void OnDeleteCinema()
        {
            if (Cinemas.Count > 0)
            {
                var cinemaToDelete = Cinemas[0]; // Selecciona la primera sala (puedes usar un selector)
                await _firebaseService.DeleteDataAsync("cinemas", cinemaToDelete.CinemaId);
                LoadCinemas(); // Recargar la lista de salas
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}