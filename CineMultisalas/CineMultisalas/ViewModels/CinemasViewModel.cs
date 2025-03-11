using CineMultisalas.Models;
using CineMultisalas.Services;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

internal class CinemasViewModel : INotifyPropertyChanged
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
        AddCinemaCommand = new RelayCommand(OnAddCinema);
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
    public async void OnAddCinema()
    {
        var newCinema = new Cinema
        {
            CinemaId = Cinemas.Count + 1, // Generar un ID único
            Name = "Nueva Sala",
            Capacity = 100
        };

        await _firebaseService.AddDataAsync("cinemas", newCinema);
        LoadCinemas(); // Recargar la lista de salas
    }

    // Método para editar una sala existente
    public async void OnEditCinema()
    {
        if (SelectedCinema != null)
        {
            await _firebaseService.UpdateDataAsync("cinemas", SelectedCinema.CinemaId, SelectedCinema);
            LoadCinemas(); // Recargar la lista de salas
        }
    }

    // Método para eliminar una sala
    public async void OnDeleteCinema()
    {
        if (SelectedCinema != null)
        {
            await _firebaseService.DeleteDataAsync("cinemas", SelectedCinema.CinemaId);
            LoadCinemas(); // Recargar la lista de salas
        }
    }

    // Implementación de INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}