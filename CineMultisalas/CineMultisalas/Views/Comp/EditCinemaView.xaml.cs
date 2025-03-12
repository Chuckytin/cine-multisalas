using CineMultisalas.ViewModels;
using System.Windows;

namespace CineMultisalas.Views.Comp
{
    public partial class EditCinemaView : Window
    {
        private readonly CinemasViewModel _viewModel;

        public EditCinemaView(CinemasViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel; // Vincular el ViewModel a la vista
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OnEditCinema(); // Llama al método en el ViewModel
            this.Close(); // Cierra la ventana
        }
    }
}