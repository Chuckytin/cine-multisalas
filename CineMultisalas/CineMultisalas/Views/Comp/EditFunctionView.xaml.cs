using CineMultisalas.ViewModels;
using System.Windows;

namespace CineMultisalas.Views.Comp
{
    public partial class EditFunctionView : Window
    {
        private readonly FunctionsViewModel _viewModel;

        public EditFunctionView(FunctionsViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel; // Vincular el ViewModel a la vista
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.OnEditFunction(); // Llama al método en el ViewModel
            this.Close(); // Cierra la ventana
        }
    }
}