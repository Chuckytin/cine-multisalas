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

        NavigateToFilmsCommand = new RelayCommand(NavigateToFilms);
        NavigateToCinemasCommand = new RelayCommand(NavigateToCinemas);
        NavigateToFunctionsCommand = new RelayCommand(NavigateToFunctions);
        NavigateToReservationsCommand = new RelayCommand<int>(NavigateToReservations); 
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
        var functionsView = new FunctionsView(_isAdmin);
        functionsView.Show();
    }

    public void NavigateToReservations(int functionId) // Cambiar a público
    {
        var reservationsView = new ReservationsView(functionId);
        reservationsView.Show();
    }
}