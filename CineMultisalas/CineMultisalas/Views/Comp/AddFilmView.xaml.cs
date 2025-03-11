using CineMultisalas.ViewModels;
using CineMultisalas.Models;
using System.Windows;
using System.Windows.Controls;

namespace CineMultisalas.Views.Comp
{
    public partial class AddFilmView : Window
    {
        private readonly FilmsViewModel _viewModel;

        public AddFilmView(FilmsViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            // Validar que todos los campos estén completos
            if (string.IsNullOrEmpty(txtTitle.Text) || string.IsNullOrEmpty(txtDescription.Text) ||
                string.IsNullOrEmpty(txtDuration.Text) || cmbGenre.SelectedItem == null)
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            // Crear una nueva película con los datos ingresados
            var newFilm = new Film
            {
                Title = txtTitle.Text,
                Description = txtDescription.Text,
                Duration = int.Parse(txtDuration.Text),
                Genre = (cmbGenre.SelectedItem as ComboBoxItem)?.Content.ToString() // Obtener el género seleccionado
            };

            // Pasar la nueva película al ViewModel
            _viewModel.OnAddFilm(newFilm);

            // Cerrar la ventana
            this.Close();
        }
    }
}