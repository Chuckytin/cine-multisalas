using CineMultisalas.Helpers;
using CineMultisalas.ViewModels;
using CineMultisalas.Views.Comp;
using System.Windows;

namespace CineMultisalas.Views
{
    public partial class FunctionsView : Window
    {
        public FunctionsView(bool isAdmin)
        {
            InitializeComponent();
            DataContext = new FunctionsViewModel(isAdmin);

            // Actualizar la visibilidad de los botones según el rol
            btnAddFunction.Visibility = isAdmin ? Visibility.Visible : Visibility.Collapsed;
            btnEditFunction.Visibility = isAdmin ? Visibility.Visible : Visibility.Collapsed;
            btnDeleteFunction.Visibility = isAdmin ? Visibility.Visible : Visibility.Collapsed;
            btnSelectSeats.Visibility = isAdmin ? Visibility.Collapsed : Visibility.Visible;
        }

        private void ButtonSelectSeats_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (FunctionsViewModel)DataContext;
            if (viewModel.SelectedFunction == null)
            {
                MessageBox.Show("Por favor, selecciona una función para ver los asientos.");
                return;
            }

            var selectSeatsView = new SelectSeatsView(viewModel.SelectedFunction);
            selectSeatsView.ShowDialog();
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