using CineMultisalas.Models;
using CineMultisalas.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace CineMultisalas.ViewModels
{
    public class ReservationsViewModel : INotifyPropertyChanged
    {
        private readonly FirebaseService _firebaseService;
        public ObservableCollection<Reservation> Reservations { get; set; }

        public ReservationsViewModel(int functionId)
        {
            _firebaseService = new FirebaseService();
            Reservations = new ObservableCollection<Reservation>();
            LoadReservations(functionId); // Cargar las reservas para la función seleccionada
        }

        // Cargar las reservas desde Firebase para la función seleccionada
        private async void LoadReservations(int functionId)
        {
            var reservations = await _firebaseService.GetDataAsync<Reservation>("reservations");
            var filteredReservations = reservations.Where(r => r.FunctionId == functionId).ToList();
            Reservations = new ObservableCollection<Reservation>(filteredReservations);
            OnPropertyChanged(nameof(Reservations)); // Notificar cambios en la propiedad
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}