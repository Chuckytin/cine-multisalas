using CineMultisalas.Models;
using CineMultisalas.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace CineMultisalas.ViewModels
{
    public class ReservationsViewModel : INotifyPropertyChanged
    {
        private readonly FirebaseService _firebaseService;
        public ObservableCollection<ReservationGroup> Reservations { get; set; }

        public ReservationsViewModel()
        {
            _firebaseService = new FirebaseService();
            Reservations = new ObservableCollection<ReservationGroup>();
            LoadReservations(); // Cargar y agrupar las reservas
        }

        // Cargar y agrupar las reservas desde Firebase
        private async void LoadReservations()
        {
            // Cargar reservas, funciones y salas desde Firebase
            var reservations = await _firebaseService.GetDataAsync<Reservation>("reservations");
            var functions = await _firebaseService.GetDataAsync<Function>("functions");
            var cinemas = await _firebaseService.GetDataAsync<Cinema>("cinemas");

            // Agrupar las reservas por FunctionId
            var groupedReservations = reservations
                .GroupBy(r => r.FunctionId)
                .Select(g =>
                {
                    // Obtener la función correspondiente
                    var function = functions.FirstOrDefault(f => f.Id == g.Key);

                    // Obtener el nombre de la sala
                    var cinemaName = cinemas.FirstOrDefault(c => c.Id == function?.CinemaId)?.Name ?? "Desconocido";

                    return new ReservationGroup
                    {
                        FunctionId = g.Key,
                        CinemaName = cinemaName, // Asignar el nombre de la sala
                        SelectedSeats = g.SelectMany(r => r.SelectedSeats).ToList() // Combinar asientos reservados
                    };
                });

            // Asignar las reservas agrupadas a la propiedad Reservations
            Reservations = new ObservableCollection<ReservationGroup>(groupedReservations);
            OnPropertyChanged(nameof(Reservations)); // Notificar cambios en la propiedad
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    // Clase para representar un grupo de reservas
    public class ReservationGroup
    {
        public int FunctionId { get; set; } // ID de la función
        public string CinemaName { get; set; } // Nombre de la sala
        public List<int> SelectedSeats { get; set; } // Lista de asientos reservados
    }
}