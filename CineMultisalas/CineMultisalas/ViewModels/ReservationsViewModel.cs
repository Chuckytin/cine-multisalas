using CineMultisalas.Models;
using CineMultisalas.Services;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

public class ReservationsViewModel : INotifyPropertyChanged
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
        AddReservationCommand = new RelayCommand<Reservation>(OnAddReservation);
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
    public async void OnAddReservation(Reservation newReservation)
    {
        if (newReservation == null)
        {
            MessageBox.Show("Error: La reserva no puede ser nula.");
            return;
        }

        newReservation.Id = Reservations.Count + 1; // Generar un ID único
        await _firebaseService.AddDataAsync("reservations", newReservation);
        LoadReservations(); // Recargar la lista de reservas
    }

    // Método para editar una reserva existente
    public async void OnEditReservation()
    {
        if (SelectedReservation == null)
        {
            MessageBox.Show("Por favor, selecciona una reserva para editar.");
            return;
        }

        await _firebaseService.UpdateDataAsync("reservations", SelectedReservation.Id, SelectedReservation);
        LoadReservations(); // Recargar la lista de reservas
    }

    // Método para eliminar una reserva
    public async void OnDeleteReservation()
    {
        if (SelectedReservation == null)
        {
            MessageBox.Show("Por favor, selecciona una reserva para eliminar.");
            return;
        }

        try
        {
            await _firebaseService.DeleteDataAsync<Reservation>("reservations", SelectedReservation.Id); 
            LoadReservations(); // Recargar la lista de reservas
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error al eliminar la reserva: {ex.Message}");
        }
    }

    // Implementación de INotifyPropertyChanged
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}