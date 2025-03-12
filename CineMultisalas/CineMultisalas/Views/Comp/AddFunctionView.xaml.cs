using CineMultisalas.ViewModels;
using CineMultisalas.Models;
using System.Windows;

namespace CineMultisalas.Views.Comp
{
    public partial class AddFunctionView : Window
    {
        private readonly FunctionsViewModel _viewModel;

        public AddFunctionView(FunctionsViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            // Validar que todos los campos estén completos
            if (cmbFilm.SelectedItem == null || cmbCinema.SelectedItem == null ||
                dpStartTime.SelectedDate == null || dpEndTime.SelectedDate == null)
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            // Crear una nueva función con los datos ingresados
            var newFunction = new Function
            {
                FilmId = (cmbFilm.SelectedItem as Film).FilmId,
                CinemaId = (cmbCinema.SelectedItem as Cinema).CinemaId,
                StartTime = dpStartTime.SelectedDate.Value,
                EndTime = dpEndTime.SelectedDate.Value
            };

            // Pasar la nueva función al ViewModel
            _viewModel.OnAddFunction(newFunction);

            // Cerrar la ventana
            this.Close();
        }
    }
}