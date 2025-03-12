using CineMultisalas.ViewModels;
using CineMultisalas.Models;
using System.Windows;

namespace CineMultisalas.Views.Comp
{
    public partial class AddReservationView : Window
    {
        private readonly ReservationsViewModel _viewModel;

        public AddReservationView(ReservationsViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            // Validar que todos los campos estén completos
            if (cmbFunction.SelectedItem == null || string.IsNullOrEmpty(txtSeats.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            // Crear una nueva reserva con los datos ingresados
            /*
            var newReservation = new Reservation
            {
                FunctionId = (cmbFunction.SelectedItem as Function).Id,
                Seats = int.Parse(txtSeats.Text)
            };
            

            // Pasar la nueva reserva al ViewModel
            _viewModel.OnAddReservation(newReservation);
            */

            // Cerrar la ventana
            this.Close();
        }
    }
}