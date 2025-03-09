using CineMultisalas.ViewModels;
using CineMultisalas.Models;
using System;
using System.Windows;

namespace CineMultisalas.Views
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
            var newFilm = new Film
            {
                Title = txtTitle.Text,
                Description = txtDescription.Text,
                Duration = int.Parse(txtDuration.Text),
                Genre = txtGenre.Text
            };

            _viewModel.OnAddFilm(); // Llama al método en el ViewModel
            this.Close(); 
        }
    }
}