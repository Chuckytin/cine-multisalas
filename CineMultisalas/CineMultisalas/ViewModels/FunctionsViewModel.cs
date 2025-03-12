using CineMultisalas.Models;
using CineMultisalas.Services;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

public class FunctionsViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Function> _functions;
    private readonly FirebaseService _firebaseService;
    private Function _selectedFunction;

    // Propiedad para la lista de funciones
    public ObservableCollection<Function> Functions
    {
        get => _functions;
        set
        {
            _functions = value;
            OnPropertyChanged(nameof(Functions)); // Notificar cambios en la propiedad
        }
    }

    // Propiedad para la función seleccionada
    public Function SelectedFunction
    {
        get => _selectedFunction;
        set
        {
            _selectedFunction = value;
            OnPropertyChanged(nameof(SelectedFunction)); // Notificar cambios en la propiedad
        }
    }

    // Comandos para añadir, editar y eliminar funciones
    public ICommand AddFunctionCommand { get; }
    public ICommand EditFunctionCommand { get; }
    public ICommand DeleteFunctionCommand { get; }

    public FunctionsViewModel()
    {
        _firebaseService = new FirebaseService();
        Functions = new ObservableCollection<Function>();
        LoadFunctions(); // Cargar las funciones al iniciar

        // Asignar métodos a los comandos
        AddFunctionCommand = new RelayCommand<Function>(OnAddFunction);
        EditFunctionCommand = new RelayCommand(OnEditFunction);
        DeleteFunctionCommand = new RelayCommand(OnDeleteFunction);
    }

    // Cargar las funciones desde Firebase
    private async void LoadFunctions()
    {
        var functions = await _firebaseService.GetDataAsync<Function>("functions");
        Functions = new ObservableCollection<Function>(functions);
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

        await _firebaseService.UpdateDataAsync("functions", SelectedFunction.Id, SelectedFunction);
        LoadFunctions(); // Recargar la lista de funciones
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