using CineMultisalas.Models;
using CineMultisalas.Services;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using System.Linq;

public class FunctionsViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Function> _functions;
    private readonly FirebaseService _firebaseService;
    private Function _selectedFunction;
    private bool _isAdmin;
    private bool _isUser;

    // Propiedad para la lista de funciones
    public ObservableCollection<Function> Functions
    {
        get => _functions;
        set
        {
            _functions = value;
            OnPropertyChanged(nameof(Functions));
        }
    }

    // Propiedad para la lista de películas
    public ObservableCollection<Film> Films { get; set; }

    // Propiedad para la lista de salas
    public ObservableCollection<Cinema> Cinemas { get; set; }

    // Propiedad para la función seleccionada
    public Function SelectedFunction
    {
        get => _selectedFunction;
        set
        {
            _selectedFunction = value;
            OnPropertyChanged(nameof(SelectedFunction));
        }
    }

    public bool IsAdmin
    {
        get => _isAdmin;
        set
        {
            _isAdmin = value;
            OnPropertyChanged(nameof(IsAdmin));
        }
    }

    public bool IsUser
    {
        get => _isUser;
        set
        {
            _isUser = value;
            OnPropertyChanged(nameof(IsUser));
        }
    }

    // Comandos para añadir, editar y eliminar funciones
    public ICommand AddFunctionCommand { get; }
    public ICommand EditFunctionCommand { get; }
    public ICommand DeleteFunctionCommand { get; }

    public FunctionsViewModel(bool isAdmin)
    {
        _firebaseService = new FirebaseService();
        Functions = new ObservableCollection<Function>();
        Films = new ObservableCollection<Film>();
        Cinemas = new ObservableCollection<Cinema>();

        IsAdmin = isAdmin; // Establece si es admin o no
        IsUser = !isAdmin; // Si no es admin, es user

        LoadFunctions();
        LoadFilms();
        LoadCinemas();

        AddFunctionCommand = new RelayCommand<Function>(OnAddFunction);
        EditFunctionCommand = new RelayCommand(OnEditFunction);
        DeleteFunctionCommand = new RelayCommand(OnDeleteFunction);
    }

    // Cargar las funciones desde Firebase
    private async void LoadFunctions()
    {
        var functions = await _firebaseService.GetDataAsync<Function>("functions");
        var films = await _firebaseService.GetDataAsync<Film>("films");
        var cinemas = await _firebaseService.GetDataAsync<Cinema>("cinemas");

        foreach (var function in functions)
        {
            // Asignar la película y la sala correspondientes a la función
            function.Film = films.FirstOrDefault(f => f.Id == function.FilmId);
            function.Cinema = cinemas.FirstOrDefault(c => c.Id == function.CinemaId);
        }

        Functions = new ObservableCollection<Function>(functions);
    }

    // Cargar las películas desde Firebase
    private async void LoadFilms()
    {
        var films = await _firebaseService.GetDataAsync<Film>("films");
        Films = new ObservableCollection<Film>(films);
    }

    // Cargar las salas desde Firebase
    private async void LoadCinemas()
    {
        var cinemas = await _firebaseService.GetDataAsync<Cinema>("cinemas");
        Cinemas = new ObservableCollection<Cinema>(cinemas);
    }

    // Método para añadir una nueva función
    public async void OnAddFunction(Function newFunction)
    {
        if (newFunction == null)
        {
            MessageBox.Show("Error: La función no puede ser nula.");
            return;
        }

        newFunction.Id = Functions.Count + 1; // Generar un ID único
        await _firebaseService.AddDataAsync("functions", newFunction);
        LoadFunctions(); // Recargar la lista de funciones
    }

    // Método para editar una función existente
    public async void OnEditFunction()
    {
        if (SelectedFunction == null)
        {
            MessageBox.Show("Por favor, selecciona una función para editar.");
            return;
        }

        try
        {
            await _firebaseService.UpdateDataAsync("functions", SelectedFunction.Id, SelectedFunction);
            LoadFunctions(); // Recargar la lista de funciones después de la edición
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al editar la función: {ex.Message}");
        }
    }

    // Método para eliminar una función
    public async void OnDeleteFunction()
    {
        if (SelectedFunction == null)
        {
            MessageBox.Show("Por favor, selecciona una función para eliminar.");
            return;
        }

        try
        {
            await _firebaseService.DeleteDataAsync<Function>("functions", SelectedFunction.Id);
            LoadFunctions(); // Recargar la lista de funciones
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al eliminar la función: {ex.Message}");
        }
    }

    // Implementación de INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}