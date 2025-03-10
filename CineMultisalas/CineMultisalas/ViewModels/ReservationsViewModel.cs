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
        private readonly FirebaseService _firebaseService;

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
            _firebaseService = new FirebaseService();
            LoadReservations();
            AddReservationCommand = new RelayCommand(OnAddReservation);
            EditReservationCommand = new RelayCommand(OnEditReservation);
            DeleteReservationCommand = new RelayCommand(OnDeleteReservation);
        }

        private async void LoadReservations()
        {
            // Cargar reservas desde Firebase
            var reservations = await _firebaseService.GetDataAsync<Reservation>("reservations");
            Reservations = new ObservableCollection<Reservation>(reservations);
        }

        private async void OnAddReservation()
        {
            // Lógica para añadir una nueva reserva
            var newReservation = new Reservation
            {
                UserId = 1, // Ejemplo: ID del usuario
                FunctionId = 1, // Ejemplo: ID de la función
                Seats = 2 // Ejemplo: Número de asientos
            };

            await _firebaseService.AddDataAsync("reservations", newReservation);
            LoadReservations(); // Recargar la lista de reservas
        }

        private async void OnEditReservation()
        {
            // Lógica para editar una reserva existente
            if (Reservations.Count > 0)
            {
                var reservationToEdit = Reservations[0]; // Ejemplo: Selecciona la primera reserva
                reservationToEdit.Seats = 4; // Ejemplo: Cambiar el número de asientos

                await _firebaseService.UpdateDataAsync("reservations", reservationToEdit.ReservationId, reservationToEdit);
                LoadReservations(); // Recargar la lista de reservas
            }
        }

        private async void OnDeleteReservation()
        {
            // Lógica para eliminar una reserva
            if (Reservations.Count > 0)
            {
                var reservationToDelete = Reservations[0]; // Ejemplo: Selecciona la primera reserva
                await _firebaseService.DeleteDataAsync("reservations", reservationToDelete.ReservationId);
                LoadReservations(); // Recargar la lista de reservas
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}