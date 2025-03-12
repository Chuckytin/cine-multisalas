using CineMultisalas.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace CineMultisalas.ViewModels
{
    public class SelectSeatsViewModel : INotifyPropertyChanged
    {
        private readonly int _capacity;
        private readonly int _rows;

        public ObservableCollection<Seat> Seats { get; set; }
        public int Rows => _rows;

        public SelectSeatsViewModel(int capacity)
        {
            _capacity = capacity;
            _rows = CalculateRows(capacity); // Calcular el número de filas
            Seats = GenerateSeats(); // Generar los asientos
        }

        // Calcular el número de filas (6 filas por defecto, más una fila adicional si hay resto)
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
                seats.Add(new Seat { SeatNumber = i });
            }
            return seats;
        }

        // Obtener los asientos seleccionados
        public ObservableCollection<Seat> GetSelectedSeats()
        {
            return new ObservableCollection<Seat>(Seats.Where(s => s.IsSelected));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}