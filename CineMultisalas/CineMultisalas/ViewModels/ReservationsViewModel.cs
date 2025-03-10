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

    public ObservableCollection<Reservation> Reservations
    {
        get => _reservations;
        set
        {
            _reservations = value;
            OnPropertyChanged(nameof(Reservations));
        }
    }

    public Reservation SelectedReservation
    {
        get => _selectedReservation;
        set
        {
            _selectedReservation = value;
            OnPropertyChanged(nameof(SelectedReservation));
        }
    }

    public ICommand AddReservationCommand { get; }
    public ICommand EditReservationCommand { get; }
    public ICommand DeleteReservationCommand { get; }

    public ReservationsViewModel()
    {
        _firebaseService = new FirebaseService();
        Reservations = new ObservableCollection<Reservation>();
        LoadReservations();

        AddReservationCommand = new RelayCommand(OnAddReservation);
        EditReservationCommand = new RelayCommand(OnEditReservation);
        DeleteReservationCommand = new RelayCommand(OnDeleteReservation);
    }

    private async void LoadReservations()
    {
        var reservations = await _firebaseService.GetDataAsync<Reservation>("reservations");
        Reservations = new ObservableCollection<Reservation>(reservations);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public async void OnAddReservation()
    {
        var newReservation = new Reservation
        {
            ReservationId = Reservations.Count + 1,
            UserId = 1, // Ejemplo: ID del usuario
            FunctionId = 1, // Ejemplo: ID de la función
            Seats = 2 // Ejemplo: Número de asientos
        };

        await _firebaseService.AddDataAsync("reservations", newReservation);
        LoadReservations();
    }

    public async void OnEditReservation()
    {
        if (SelectedReservation != null)
        {
            await _firebaseService.UpdateDataAsync("reservations", SelectedReservation.ReservationId, SelectedReservation);
            LoadReservations();
        }
    }

    public async void OnDeleteReservation()
    {
        if (SelectedReservation != null)
        {
            await _firebaseService.DeleteDataAsync("reservations", SelectedReservation.ReservationId);
            LoadReservations();
        }
    }

    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}