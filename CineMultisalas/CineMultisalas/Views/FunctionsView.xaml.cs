using CineMultisalas.Helpers;
using CineMultisalas.ViewModels;
using CineMultisalas.Views.Comp;
using System.Windows;

namespace CineMultisalas.Views
{
    public partial class FunctionsView : Window
    {
        public FunctionsView()
        {
            InitializeComponent();
            DataContext = new FunctionsViewModel();
        }

        private void ButtonAddFunction_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (FunctionsViewModel)DataContext;
            var addFunctionView = new AddFunctionView(viewModel);
            addFunctionView.ShowDialog();
        }

        private void ButtonEditFunction_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (FunctionsViewModel)DataContext;
            if (viewModel.SelectedFunction == null)
            {
                MessageBox.Show("Por favor, selecciona una función para editar.");
                return;
            }

            var editFunctionView = new EditFunctionView(viewModel);
            editFunctionView.ShowDialog();
        }

        private void ButtonDeleteFunction_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (FunctionsViewModel)DataContext;
            if (viewModel.SelectedFunction == null)
            {
                MessageBox.Show("Por favor, selecciona una función para eliminar.");
                return;
            }

            var deleteFunctionView = new DeleteFunctionView(viewModel);
            deleteFunctionView.ShowDialog();
        }

        private void ButtonHelp_Click(object sender, RoutedEventArgs e)
        {
            string helpMessage = ContextualHelps.GetHelp("FunctionsView");
            MessageBox.Show(helpMessage, "Ayuda Contextual", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}