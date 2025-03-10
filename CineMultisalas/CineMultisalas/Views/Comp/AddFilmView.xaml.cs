using CineMultisalas.ViewModels;
using CineMultisalas.Models;
using System;
using System.Windows;

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
            if (string.IsNullOrEmpty(txtTitle.Text) || string.IsNullOrEmpty(txtDescription.Text) ||
                string.IsNullOrEmpty(txtDuration.Text) || string.IsNullOrEmpty(txtGenre.Text))
            {
                MessageBox.Show("Por favor, completa todos los campos.");
                return;
            }

            var newFilm = new Film
            {
                Title = txtTitle.Text,
                Description = txtDescription.Text,
                Duration = int.Parse(txtDuration.Text),
                Genre = txtGenre.Text
            };

            _viewModel.OnAddFilm(newFilm); // Pasa la nueva película al ViewModel
            this.Close();
        }
    }
}