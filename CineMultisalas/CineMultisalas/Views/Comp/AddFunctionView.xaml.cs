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
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            // Verificar si algún campo está vacío
            if (cmbFilm.SelectedItem == null || cmbCinema.SelectedItem == null ||
                dpDate.SelectedDate == null || string.IsNullOrEmpty(cmbStartTime.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            // Validar que SelectedValue no sea nulo
            if (cmbFilm.SelectedValue == null || cmbCinema.SelectedValue == null)
            {
                MessageBox.Show("Error: No se seleccionó una película o sala válida.");
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
                FilmId = (int)cmbFilm.SelectedValue,
                CinemaId = (int)cmbCinema.SelectedValue,
                StartTime = dpDate.SelectedDate.Value + startTime
            };

            // Verificar que newFunction no sea nulo antes de enviarlo al ViewModel
            if (newFunction == null)
            {
                MessageBox.Show("Error: La función no puede ser nula.");
                return;
            }

            // Pasar la nueva función al ViewModel
            _viewModel.OnAddFunction(newFunction);

            // Cerrar la ventana
            this.Close();
        }

    }
}