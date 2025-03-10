using CineMultisalas.ViewModels;
using System.Windows;

namespace CineMultisalas.Views.Comp
{
    public partial class DeleteFilmView : Window
    {
        private readonly FilmsViewModel _viewModel;

        public DeleteFilmView(FilmsViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OnDeleteFilm(); // Llama al método en el ViewModel
            this.Close(); // Cierra la ventana
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Cierra la ventana sin hacer nada
        }
    }
}