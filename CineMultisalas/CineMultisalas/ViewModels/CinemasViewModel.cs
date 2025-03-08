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
            LoadCinemas();
            AddCinemaCommand = new RelayCommand(OnAddCinema);
            EditCinemaCommand = new RelayCommand(OnEditCinema);
            DeleteCinemaCommand = new RelayCommand(OnDeleteCinema);
        }

        private async void LoadCinemas()
        {
            // Cargar salas desde DatabaseService
            var databaseService = new DatabaseService("YourConnectionString");
            var cinemas = await databaseService.GetCinemasAsync();
            Cinemas = new ObservableCollection<Cinema>(cinemas);
        }

        private void OnAddCinema()
        {
            // Lógica para añadir una nueva sala
        }

        private void OnEditCinema()
        {
            // Lógica para editar una sala existente
        }

        private void OnDeleteCinema()
        {
            // Lógica para eliminar una sala
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}