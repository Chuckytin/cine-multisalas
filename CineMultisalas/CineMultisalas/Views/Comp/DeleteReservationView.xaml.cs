using CineMultisalas.ViewModels;
using System.Windows;

namespace CineMultisalas.Views.Comp
{
    public partial class DeleteReservationView : Window
    {
        private readonly ReservationsViewModel _viewModel;

        public DeleteReservationView(ReservationsViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OnDeleteReservation(); // Llama al método en el ViewModel
            this.Close(); // Cierra la ventana
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Cierra la ventana sin hacer nada
        }
    }
}