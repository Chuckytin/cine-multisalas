using CineMultisalas.Models;
using CineMultisalas.ViewModels;
using System.Linq;
using System.Windows;

namespace CineMultisalas.Views
{
    public partial class SelectSeatsView : Window
    {
        public SelectSeatsView(Function selectedFunction)
        {
            InitializeComponent();
            DataContext = new SelectSeatsViewModel(selectedFunction.Cinema.Capacity);
        }

        private void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (SelectSeatsViewModel)DataContext;
            var selectedSeats = viewModel.GetSelectedSeats();

            if (selectedSeats.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona al menos un asiento.");
                return;
            }

            // Aquí puedes guardar la reserva con los asientos seleccionados
            MessageBox.Show($"Asientos seleccionados: {string.Join(", ", selectedSeats.Select(s => s.SeatNumber))}");
            this.Close();
        }
    }
}