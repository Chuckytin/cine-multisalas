using CineMultisalas.ViewModels;
using System.Windows;

namespace CineMultisalas.Views.Comp
{
    public partial class DeleteFunctionView : Window
    {
        private readonly FunctionsViewModel _viewModel;

        public DeleteFunctionView(FunctionsViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OnDeleteFunction(); // Llama al método en el ViewModel
            this.Close(); // Cierra la ventana
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close(); // Cierra la ventana sin hacer nada
        }
    }
}