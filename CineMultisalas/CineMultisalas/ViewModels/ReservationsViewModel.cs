using CineMultisalas.Models;
using CineMultisalas.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace CineMultisalas.ViewModels
{
    public class ReservationsViewModel : INotifyPropertyChanged
    {
        private readonly FirebaseService _firebaseService;
        private readonly int? _functionId; // Usar int? para permitir valores nulos

        public ObservableCollection<Reservation> Reservations { get; set; }

        // Constructor sin parámetros (carga todas las reservas)
        public ReservationsViewModel()
        {
            _firebaseService = new FirebaseService();
            Reservations = new ObservableCollection<Reservation>();
            LoadReservations(); // Cargar todas las reservas
        }

        // Constructor con functionId (carga reservas filtradas)
        public ReservationsViewModel(int functionId)
        {
            _firebaseService = new FirebaseService();
            _functionId = functionId;
            Reservations = new ObservableCollection<Reservation>();
            LoadReservations(); // Cargar reservas filtradas
        }

        // Cargar reservas desde Firebase
        private async void LoadReservations()
        {
            var reservations = await _firebaseService.GetDataAsync<Reservation>("reservations");

            // Filtrar solo si functionId tiene un valor
            if (_functionId.HasValue)
            {
                reservations = reservations.Where(r => r.FunctionId == _functionId.Value).ToList();
            }

            Reservations = new ObservableCollection<Reservation>(reservations);
            OnPropertyChanged(nameof(Reservations));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}