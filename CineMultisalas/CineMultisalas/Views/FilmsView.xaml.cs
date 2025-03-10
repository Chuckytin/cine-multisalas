using CineMultisalas.Helpers;
using CineMultisalas.ViewModels;
using CineMultisalas.Views.Comp;
using System.Windows;

namespace CineMultisalas.Views
{
    public partial class FilmsView : Window
    {
        public FilmsView()
        {
            InitializeComponent();
            DataContext = new FilmsViewModel();
        }

        private void ButtonAddFilm_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (FilmsViewModel)DataContext;
            var addFilmView = new AddFilmView(viewModel);
            addFilmView.ShowDialog();
        }

        private void ButtonEditFilm_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (FilmsViewModel)DataContext;
            if (viewModel.SelectedFilm == null)
            {
                MessageBox.Show("Por favor, selecciona una película para editar.");
                return;
            }

            var editFilmView = new EditFilmView(viewModel);
            editFilmView.ShowDialog();
        }

        private void ButtonDeleteFilm_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (FilmsViewModel)DataContext;
            if (viewModel.SelectedFilm == null)
            {
                MessageBox.Show("Por favor, selecciona una película para eliminar.");
                return;
            }

            var deleteFilmView = new DeleteFilmView(viewModel);
            deleteFilmView.ShowDialog();
        }

        private void ButtonHelp_Click(object sender, RoutedEventArgs e)
        {
            string helpMessage = ContextualHelps.GetHelp("FilmsView");
            MessageBox.Show(helpMessage, "Ayuda Contextual", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}