using CineMultisalas.ViewModels;
using System.Windows;

namespace CineMultisalas.Views.Comp
{
    public partial class DeleteCinemaView : Window
    {
        private readonly CinemasViewModel _viewModel;

        public DeleteCinemaView(CinemasViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OnDeleteCinema(); // Llama al método en el ViewModel
            this.Close(); // Cierra la ventana
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Cierra la ventana sin hacer nada
        }
    }
}