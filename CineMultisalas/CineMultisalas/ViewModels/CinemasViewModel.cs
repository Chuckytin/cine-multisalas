using CineMultisalas.Models;
using CineMultisalas.Services;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

public class CinemasViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Cinema> _cinemas;
    private readonly FirebaseService _firebaseService;
    private Cinema _selectedCinema;

    // Propiedad para la lista de salas
    public ObservableCollection<Cinema> Cinemas
    {
        get => _cinemas;
        set
        {
            _cinemas = value;
            OnPropertyChanged(nameof(Cinemas)); // Notificar cambios en la propiedad
        }
    }

    // Propiedad para la sala seleccionada
    public Cinema SelectedCinema
    {
        get => _selectedCinema;
        set
        {
            _selectedCinema = value;
            OnPropertyChanged(nameof(SelectedCinema)); // Notificar cambios en la propiedad
        }
    }

    // Comandos para añadir, editar y eliminar salas
    public ICommand AddCinemaCommand { get; }
    public ICommand EditCinemaCommand { get; }
    public ICommand DeleteCinemaCommand { get; }

    public CinemasViewModel()
    {
        _firebaseService = new FirebaseService();
        Cinemas = new ObservableCollection<Cinema>();
        LoadCinemas(); // Cargar las salas al iniciar

        // Asignar métodos a los comandos
        AddCinemaCommand = new RelayCommand<Cinema>(OnAddCinema);
        EditCinemaCommand = new RelayCommand(OnEditCinema);
        DeleteCinemaCommand = new RelayCommand(OnDeleteCinema);
    }

    // Cargar las salas desde Firebase
    private async void LoadCinemas()
    {
        var cinemas = await _firebaseService.GetDataAsync<Cinema>("cinemas");
        Cinemas = new ObservableCollection<Cinema>(cinemas);
    }

    // Método para añadir una nueva sala
    public async void OnAddCinema(Cinema newCinema)
    {
        if (newCinema == null)
        {
            MessageBox.Show("Error: La sala no puede ser nula.");
            return;
        }

        newCinema.Id = Cinemas.Count + 1; // Generar un ID único
        await _firebaseService.AddDataAsync("cinemas", newCinema);
        LoadCinemas(); // Recargar la lista de salas
    }

    // Método para editar una sala existente
    public async void OnEditCinema()
    {

        if (SelectedCinema == null)
        {
            MessageBox.Show("Por favor, selecciona una sala para editar.");
            return;
        }

        await _firebaseService.UpdateDataAsync("cinemas", SelectedCinema.Id, SelectedCinema);
        LoadCinemas(); 
    }

    // Método para eliminar una sala
    public async void OnDeleteCinema()
    {
        if (SelectedCinema == null)
        {
            MessageBox.Show("Por favor, selecciona una sala para eliminar.");
            return;
        }

        try
        {
            await _firebaseService.DeleteDataAsync<Cinema>("cinemas", SelectedCinema.Id); // Especificar el tipo <Cinema>
            LoadCinemas(); // Recargar la lista de salas
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al eliminar la sala: {ex.Message}");
        }
    }

    // Implementación de INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}