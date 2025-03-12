using CineMultisalas.ViewModels;
using System.Windows;

namespace CineMultisalas.Views.Comp
{
    public partial class EditReservationView : Window
    {
        private readonly ReservationsViewModel _viewModel;

        public EditReservationView(ReservationsViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel; // Vincular el ViewModel a la vista
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OnEditReservation(); // Llama al método en el ViewModel
            this.Close(); // Cierra la ventana
        }
    }
}