using CineMultisalas.Models;
using CineMultisalas.Services;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace CineMultisalas.ViewModels
{
    internal class ReservationsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Reservation> _reservations;
        public ObservableCollection<Reservation> Reservations
        {
            get => _reservations;
            set
            {
                _reservations = value;
                OnPropertyChanged(nameof(Reservations));
            }
        }

        public ICommand AddReservationCommand { get; }
        public ICommand EditReservationCommand { get; }
        public ICommand DeleteReservationCommand { get; }

        public ReservationsViewModel()
        {
            LoadReservations();
            AddReservationCommand = new RelayCommand(OnAddReservation);
            EditReservationCommand = new RelayCommand(OnEditReservation);
            DeleteReservationCommand = new RelayCommand(OnDeleteReservation);
        }

        private async void LoadReservations()
        {
            // Cargar reservas desde DatabaseService
            var databaseService = new DatabaseService("YourConnectionString");
            var reservations = await databaseService.GetReservationsAsync();
            Reservations = new ObservableCollection<Reservation>(reservations);
        }

        private void OnAddReservation()
        {
            // Lógica para añadir una nueva reserva
        }

        private void OnEditReservation()
        {
            // Lógica para editar una reserva existente
        }

        private void OnDeleteReservation()
        {
            // Lógica para eliminar una reserva
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}