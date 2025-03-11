using CineMultisalas.Models;
using CineMultisalas.Services;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

internal class ReservationsViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Reservation> _reservations;
    private readonly FirebaseService _firebaseService;
    private Reservation _selectedReservation;

    // Propiedad para la lista de reservas
    public ObservableCollection<Reservation> Reservations
    {
        get => _reservations;
        set
        {
            _reservations = value;
            OnPropertyChanged(nameof(Reservations)); // Notificar cambios en la propiedad
        }
    }

    // Propiedad para la reserva seleccionada
    public Reservation SelectedReservation
    {
        get => _selectedReservation;
        set
        {
            _selectedReservation = value;
            OnPropertyChanged(nameof(SelectedReservation)); // Notificar cambios en la propiedad
        }
    }

    // Comandos para añadir, editar y eliminar reservas
    public ICommand AddReservationCommand { get; }
    public ICommand EditReservationCommand { get; }
    public ICommand DeleteReservationCommand { get; }

    public ReservationsViewModel()
    {
        _firebaseService = new FirebaseService();
        Reservations = new ObservableCollection<Reservation>();
        LoadReservations(); // Cargar las reservas al iniciar

        // Asignar métodos a los comandos
        AddReservationCommand = new RelayCommand(OnAddReservation);
        EditReservationCommand = new RelayCommand(OnEditReservation);
        DeleteReservationCommand = new RelayCommand(OnDeleteReservation);
    }

    // Cargar las reservas desde Firebase
    private async void LoadReservations()
    {
        var reservations = await _firebaseService.GetDataAsync<Reservation>("reservations");
        Reservations = new ObservableCollection<Reservation>(reservations);
    }

    // Método para añadir una nueva reserva
    public async void OnAddReservation()
    {
        var newReservation = new Reservation
        {
            ReservationId = Reservations.Count + 1, // Generar un ID único
            UserId = 1, // Ejemplo: ID del usuario
            FunctionId = 1, // Ejemplo: ID de la función
            Seats = 2 // Ejemplo: Número de asientos
        };

        await _firebaseService.AddDataAsync("reservations", newReservation);
        LoadReservations(); // Recargar la lista de reservas
    }

    // Método para editar una reserva existente
    public async void OnEditReservation()
    {
        if (SelectedReservation != null)
        {
            await _firebaseService.UpdateDataAsync("reservations", SelectedReservation.ReservationId, SelectedReservation);
            LoadReservations(); // Recargar la lista de reservas
        }
    }

    // Método para eliminar una reserva
    public async void OnDeleteReservation()
    {
        if (SelectedReservation != null)
        {
            await _firebaseService.DeleteDataAsync("reservations", SelectedReservation.ReservationId);
            LoadReservations(); // Recargar la lista de reservas
        }
    }

    // Implementación de INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}