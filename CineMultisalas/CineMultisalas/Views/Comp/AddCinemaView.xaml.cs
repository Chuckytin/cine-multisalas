using CineMultisalas.ViewModels;
using CineMultisalas.Models;
using System.Windows;

namespace CineMultisalas.Views.Comp
{
    public partial class AddCinemaView : Window
    {
        private readonly CinemasViewModel _viewModel;

        public AddCinemaView(CinemasViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            // Validar que todos los campos estén completos
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtCapacity.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            // Crear una nueva sala con los datos ingresados
            var newCinema = new Cinema
            {
                Name = txtName.Text,
                Capacity = int.Parse(txtCapacity.Text)
            };

            // Pasar la nueva sala al ViewModel
            _viewModel.OnAddCinema(newCinema);

            // Cerrar la ventana
            this.Close();
        }
    }
}