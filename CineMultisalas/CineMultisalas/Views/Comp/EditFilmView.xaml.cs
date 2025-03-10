using CineMultisalas.ViewModels;
using System.Windows;

namespace CineMultisalas.Views.Comp
{
    public partial class EditFilmView : Window
    {
        private readonly FilmsViewModel _viewModel;

        public EditFilmView(FilmsViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel; // Vincular el ViewModel a la vista
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OnEditFilm(); // Llama al método en el ViewModel
            this.Close(); // Cierra la ventana
        }
    }
}