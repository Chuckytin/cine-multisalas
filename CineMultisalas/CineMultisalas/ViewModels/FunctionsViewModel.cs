using CineMultisalas.Models;
using CineMultisalas.Services;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using System;

internal class FunctionsViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Function> _functions;
    private readonly FirebaseService _firebaseService;
    private Function _selectedFunction;

    public ObservableCollection<Function> Functions
    {
        get => _functions;
        set
        {
            _functions = value;
            OnPropertyChanged(nameof(Functions));
        }
    }

    public Function SelectedFunction
    {
        get => _selectedFunction;
        set
        {
            _selectedFunction = value;
            OnPropertyChanged(nameof(SelectedFunction));
        }
    }

    public ICommand AddFunctionCommand { get; }
    public ICommand EditFunctionCommand { get; }
    public ICommand DeleteFunctionCommand { get; }

    public FunctionsViewModel()
    {
        _firebaseService = new FirebaseService();
        Functions = new ObservableCollection<Function>();
        LoadFunctions();

        AddFunctionCommand = new RelayCommand(OnAddFunction);
        EditFunctionCommand = new RelayCommand(OnEditFunction);
        DeleteFunctionCommand = new RelayCommand(OnDeleteFunction);
    }

    private async void LoadFunctions()
    {
        var functions = await _firebaseService.GetDataAsync<Function>("functions");
        Functions = new ObservableCollection<Function>(functions);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public async void OnAddFunction()
    {
        var newFunction = new Function
        {
            FunctionId = Functions.Count + 1,
            FilmId = 1, // Ejemplo: ID de la película
            CinemaId = 1, // Ejemplo: ID de la sala
            StartTime = DateTime.Now, // Ejemplo: Hora de inicio
            EndTime = DateTime.Now.AddHours(2) // Ejemplo: Hora de finalización
        };

        await _firebaseService.AddDataAsync("functions", newFunction);
        LoadFunctions();
    }

    public async void OnEditFunction()
    {
        if (SelectedFunction != null)
        {
            await _firebaseService.UpdateDataAsync("functions", SelectedFunction.FunctionId, SelectedFunction);
            LoadFunctions();
        }
    }

    public async void OnDeleteFunction()
    {
        if (SelectedFunction != null)
        {
            await _firebaseService.DeleteDataAsync("functions", SelectedFunction.FunctionId);
            LoadFunctions();
        }
    }

    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}