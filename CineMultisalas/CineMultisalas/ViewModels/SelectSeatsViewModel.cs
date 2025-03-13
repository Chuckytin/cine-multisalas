using CineMultisalas.Models;
using CineMultisalas.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace CineMultisalas.ViewModels
{
    public class SelectSeatsViewModel : INotifyPropertyChanged
    {
        private readonly int _capacity;
        private readonly int _functionId;
        private readonly FirebaseService _firebaseService;

        public ObservableCollection<Seat> Seats { get; set; }
        public int Rows => CalculateRows(_capacity);

        // Propiedad para el ID de la función
        public int FunctionId => _functionId;

        public SelectSeatsViewModel(int capacity, int functionId)
        {
            _capacity = capacity;
            _functionId = functionId;
            _firebaseService = new FirebaseService();
            Seats = GenerateSeats(); // Generar los asientos
            LoadReservedSeats(); // Cargar los asientos reservados
        }

        // Calcular el número de filas
        private int CalculateRows(int capacity)
        {
            int seatsPerRow = 7; // Asientos por fila
            int rows = capacity / seatsPerRow;
            if (capacity % seatsPerRow != 0) rows++;
            return rows;
        }

        // Generar los asientos numerados
        private ObservableCollection<Seat> GenerateSeats()
        {
            var seats = new ObservableCollection<Seat>();
            for (int i = 1; i <= _capacity; i++)
            {
                seats.Add(new Seat { SeatNumber = i, IsAvailable = true });
            }
            return seats;
        }

        // Cargar los asientos reservados
        private async void LoadReservedSeats()
        {
            var reservations = await _firebaseService.GetDataAsync<Reservation>("reservations");
            var reservedSeats = reservations
                .Where(r => r.FunctionId == _functionId)
                .SelectMany(r => r.SelectedSeats)
                .ToList();

            foreach (var seat in Seats)
            {
                seat.IsAvailable = !reservedSeats.Contains(seat.SeatNumber);
            }
        }

        // Obtener los asientos seleccionados
        public ObservableCollection<Seat> GetSelectedSeats()
        {
            return new ObservableCollection<Seat>(Seats.Where(s => s.IsSelected));
        }

        // Implementación de INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}