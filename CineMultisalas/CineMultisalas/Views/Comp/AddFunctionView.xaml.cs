using CineMultisalas.ViewModels;
using CineMultisalas.Models;
using System;
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

            // Validar formato de hora
            if (!TimeSpan.TryParse(cmbStartTime.Text, out var startTime))
            {
                MessageBox.Show("Formato de hora incorrecto. Usa el formato HH:mm.");
                return;
            }

            // Crear nueva función
            var newFunction = new Function
            {
                FilmId = (int)cmbFilm.SelectedValue, // Asignar FilmId
                CinemaId = (int)cmbCinema.SelectedValue, // Asignar CinemaId
                StartTime = dpDate.SelectedDate.Value + startTime
            };

            // Pasar la nueva función al ViewModel
            _viewModel.OnAddFunction(newFunction);

            // Cerrar la ventana
            this.Close();
        }

    }
}