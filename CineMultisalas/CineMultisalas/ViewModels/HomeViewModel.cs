using CineMultisalas.Views;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;

public class HomeViewModel
{
    private readonly bool _isAdmin;

    // Comandos para navegar a las diferentes vistas
    public ICommand NavigateToFilmsCommand { get; }
    public ICommand NavigateToCinemasCommand { get; }
    public ICommand NavigateToFunctionsCommand { get; }
    public ICommand NavigateToReservationsCommand { get; }

    public HomeViewModel(bool isAdmin)
    {
        _isAdmin = isAdmin;

        // Inicializar los comandos
        NavigateToFilmsCommand = new RelayCommand(NavigateToFilms);
        NavigateToCinemasCommand = new RelayCommand(NavigateToCinemas);
        NavigateToFunctionsCommand = new RelayCommand(NavigateToFunctions);
        NavigateToReservationsCommand = new RelayCommand(NavigateToReservations);
    }

    // Métodos para navegar a las vistas
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
        var functionsView = new FunctionsView(_isAdmin);
        functionsView.Show();
    }

    private void NavigateToReservations()
    {
        var reservationsView = new ReservationsView(); 
        reservationsView.Show();
    }
}