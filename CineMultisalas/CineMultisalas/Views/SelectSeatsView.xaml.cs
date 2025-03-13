using CineMultisalas.Models;
using CineMultisalas.Services;
using CineMultisalas.ViewModels;
using System;
using System.Linq;
using System.Windows;

namespace CineMultisalas.Views
{
    public partial class SelectSeatsView : Window
    {
        public SelectSeatsView(Function selectedFunction)
        {
            InitializeComponent();
            DataContext = new SelectSeatsViewModel(selectedFunction.Cinema.Capacity, selectedFunction.Id);
        }

        private async void ButtonConfirm_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (SelectSeatsViewModel)DataContext;
            var selectedSeats = viewModel.GetSelectedSeats();

            if (selectedSeats.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona al menos un asiento.");
                return;
            }

            // Crear una nueva reserva
            var newReservation = new Reservation
            {
                FunctionId = viewModel.FunctionId, // ID de la función
                SelectedSeats = selectedSeats.Select(s => s.SeatNumber).ToList() // Lista de asientos seleccionados
            };

            // Guardar la reserva en Firebase
            var firebaseService = new FirebaseService();
            try
            {
                await firebaseService.AddDataAsync("reservations", newReservation);
                MessageBox.Show("Reserva guardada correctamente.");
                this.Close(); // Cerrar la ventana después de guardar
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar la reserva: {ex.Message}");
            }
        }
    }
}