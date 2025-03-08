using CommunityToolkit.Mvvm.Input;
using CineMultisalas.Views;
using System.Windows.Input;

namespace CineMultisalas.ViewModels
{
    internal class HomeViewModel
    {
        // Comandos para navegar a las diferentes vistas
        public ICommand NavigateToFilmsCommand { get; }
        public ICommand NavigateToCinemasCommand { get; }
        public ICommand NavigateToFunctionsCommand { get; }
        public ICommand NavigateToReservationsCommand { get; }

        public HomeViewModel()
        {
            NavigateToFilmsCommand = new RelayCommand(NavigateToFilms);
            NavigateToCinemasCommand = new RelayCommand(NavigateToCinemas);
            NavigateToFunctionsCommand = new RelayCommand(NavigateToFunctions);
            NavigateToReservationsCommand = new RelayCommand(NavigateToReservations);
        }

        private void NavigateToFilms()
        {
            var filmsView = new FilmsView();
            filmsView.Show();
        }

        private void NavigateToCinemas()
        {
            var cinemasView = new CinemasView();
            cinemasView.Show();
        }

        private void NavigateToFunctions()
        {
            var functionsView = new FunctionsView();
            functionsView.Show();
        }

        private void NavigateToReservations()
        {
            var reservationsView = new ReservationsView();
            reservationsView.Show();
        }
    }
}