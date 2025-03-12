using CineMultisalas.Helpers;
using CineMultisalas.ViewModels;
using CineMultisalas.Views.Comp;
using System.Windows;

namespace CineMultisalas.Views
{
    public partial class CinemasView : Window
    {
        public CinemasView()
        {
            InitializeComponent();
            DataContext = new CinemasViewModel();
        }

        private void ButtonAddCinema_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (CinemasViewModel)DataContext;
            var addCinemaView = new AddCinemaView(viewModel);
            addCinemaView.ShowDialog();
        }

        private void ButtonEditCinema_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (CinemasViewModel)DataContext;
            if (viewModel.SelectedCinema == null)
            {
                MessageBox.Show("Por favor, selecciona una sala para editar.");
                return;
            }

            var editCinemaView = new EditCinemaView(viewModel);
            editCinemaView.ShowDialog();
        }

        private void ButtonDeleteCinema_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (CinemasViewModel)DataContext;
            if (viewModel.SelectedCinema == null)
            {
                MessageBox.Show("Por favor, selecciona una sala para eliminar.");
                return;
            }

            var deleteCinemaView = new DeleteCinemaView(viewModel);
            deleteCinemaView.ShowDialog();
        }

        private void MenuItemLogout_Click(object sender, RoutedEventArgs e)
        {
            // Cierra sesión y vuelve a la ventana de login
            var loginView = new LoginView();
            loginView.Show();
            this.Close();
        }

        private void MenuItemHelp_Click(object sender, RoutedEventArgs e)
        {
            string helpMessage = ContextualHelps.GetHelp("CinemasView");
            MessageBox.Show(helpMessage, "Ayuda Contextual", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        
    }
}