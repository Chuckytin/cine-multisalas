using CineMultisalas.ViewModels;
using System;
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

            // Cargar películas y salas
            cmbFilm.ItemsSource = _viewModel.Films;
            cmbCinema.ItemsSource = _viewModel.Cinemas;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            // Validar que todos los campos estén completos
            if (cmbFilm.SelectedItem == null || cmbCinema.SelectedItem == null ||
                dpDate.SelectedDate == null || string.IsNullOrEmpty(cmbStartTime.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            // Validar el formato de la hora (HH:mm)
            if (!TimeSpan.TryParse(cmbStartTime.Text, out var startTime))
            {
                MessageBox.Show("Formato de hora incorrecto. Usa el formato HH:mm.");
                return;
            }

            // Actualizar FilmId (con verificación segura)
            if (cmbFilm.SelectedValue != null && int.TryParse(cmbFilm.SelectedValue.ToString(), out int filmId))
            {
                _viewModel.SelectedFunction.FilmId = filmId;
            }
            else
            {
                MessageBox.Show("Error: No se pudo obtener el ID de la película.");
                return;
            }

            // Actualizar CinemaId (con verificación segura)
            if (cmbCinema.SelectedValue != null && int.TryParse(cmbCinema.SelectedValue.ToString(), out int cinemaId))
            {
                _viewModel.SelectedFunction.CinemaId = cinemaId;
            }
            else
            {
                MessageBox.Show("Error: No se pudo obtener el ID de la sala.");
                return;
            }

            // Actualizar StartTime
            _viewModel.SelectedFunction.StartTime = dpDate.SelectedDate.Value + startTime;

            // Guardar los cambios
            _viewModel.OnEditFunction();

            // Cerrar la ventana
            this.Close();
        }
    }
}