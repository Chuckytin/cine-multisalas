using CineMultisalas.Helpers;
using CineMultisalas.ViewModels;
using CineMultisalas.Views.Comp;
using System.Windows;

namespace CineMultisalas.Views
{
    public partial class ReservationsView : Window
    {
        public ReservationsView()
        {
            InitializeComponent();
            DataContext = new ReservationsViewModel();
        }

        private void ButtonAddReservation_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (ReservationsViewModel)DataContext;
            var addReservationView = new AddReservationView(viewModel);
            addReservationView.ShowDialog();
        }

        private void ButtonEditReservation_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (ReservationsViewModel)DataContext;
            if (viewModel.SelectedReservation == null)
            {
                MessageBox.Show("Por favor, selecciona una reserva para editar.");
                return;
            }

            var editReservationView = new EditReservationView(viewModel);
            editReservationView.ShowDialog();
        }

        private void ButtonDeleteReservation_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (ReservationsViewModel)DataContext;
            if (viewModel.SelectedReservation == null)
            {
                MessageBox.Show("Por favor, selecciona una reserva para eliminar.");
                return;
            }

            var deleteReservationView = new DeleteReservationView(viewModel);
            deleteReservationView.ShowDialog();
        }

        private void ButtonHelp_Click(object sender, RoutedEventArgs e)
        {
            string helpMessage = ContextualHelps.GetHelp("ReservationsView");
            MessageBox.Show(helpMessage, "Ayuda Contextual", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}