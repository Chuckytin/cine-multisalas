using CineMultisalas.Models;
using CineMultisalas.Services;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace CineMultisalas.ViewModels
{
    public class FilmsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Film> _films;
        private readonly FirebaseService _firebaseService;
        private Film _selectedFilm;

        public ObservableCollection<Film> Films
        {
            get => _films;
            set
            {
                _films = value;
                OnPropertyChanged(nameof(Films));
            }
        }

        public Film SelectedFilm
        {
            get => _selectedFilm;
            set
            {
                _selectedFilm = value;
                OnPropertyChanged(nameof(SelectedFilm));
            }
        }

        public ICommand AddFilmCommand { get; }
        public ICommand EditFilmCommand { get; }
        public ICommand DeleteFilmCommand { get; }

        public FilmsViewModel()
        {
            _firebaseService = new FirebaseService();
            Films = new ObservableCollection<Film>();
            LoadFilms();

            AddFilmCommand = new RelayCommand<Film>(OnAddFilm);
            EditFilmCommand = new RelayCommand(OnEditFilm);
            DeleteFilmCommand = new RelayCommand(OnDeleteFilm);
        }

        private async void LoadFilms()
        {
            var films = await _firebaseService.GetDataAsync<Film>("films");
            Films = new ObservableCollection<Film>(films);
        }

        public async void OnAddFilm(Film newFilm)
        {
            if (newFilm == null)
            {
                MessageBox.Show("Error: La película no puede ser nula.");
                return;
            }

            newFilm.Id = Films.Count + 1; // Generar un ID único
            await _firebaseService.AddDataAsync("films", newFilm);
            LoadFilms();
        }

        public async void OnEditFilm()
        {
            if (SelectedFilm == null)
            {
                MessageBox.Show("Por favor, selecciona una película para editar.");
                return;
            }

            await _firebaseService.UpdateDataAsync("films", SelectedFilm.Id, SelectedFilm);
            LoadFilms();
        }

        public async void OnDeleteFilm()
        {
            if (SelectedFilm == null)
            {
                MessageBox.Show("Por favor, selecciona una película para eliminar.");
                return;
            }

            try
            {
                await _firebaseService.DeleteDataAsync<Film>("films", SelectedFilm.Id);
                LoadFilms();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la película: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}