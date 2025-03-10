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

    public ObservableCollection<Cinema> Cinemas
    {
        get => _cinemas;
        set
        {
            _cinemas = value;
            OnPropertyChanged(nameof(Cinemas));
        }
    }

    public Cinema SelectedCinema
    {
        get => _selectedCinema;
        set
        {
            _selectedCinema = value;
            OnPropertyChanged(nameof(SelectedCinema));
        }
    }

    public ICommand AddCinemaCommand { get; }
    public ICommand EditCinemaCommand { get; }
    public ICommand DeleteCinemaCommand { get; }

    public CinemasViewModel()
    {
        _firebaseService = new FirebaseService();
        Cinemas = new ObservableCollection<Cinema>();
        LoadCinemas();

        AddCinemaCommand = new RelayCommand(OnAddCinema);
        EditCinemaCommand = new RelayCommand(OnEditCinema);
        DeleteCinemaCommand = new RelayCommand(OnDeleteCinema);
    }

    private async void LoadCinemas()
    {
        var cinemas = await _firebaseService.GetDataAsync<Cinema>("cinemas");
        Cinemas = new ObservableCollection<Cinema>(cinemas);
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public async void OnAddCinema()
    {
        var newCinema = new Cinema
        {
            CinemaId = Cinemas.Count + 1,
            Name = "Nueva Sala",
            Capacity = 100
        };

        await _firebaseService.AddDataAsync("cinemas", newCinema);
        LoadCinemas();
    }

    public async void OnEditCinema()
    {
        if (SelectedCinema != null)
        {
            await _firebaseService.UpdateDataAsync("cinemas", SelectedCinema.CinemaId, SelectedCinema);
            LoadCinemas();
        }
    }

    public async void OnDeleteCinema()
    {
        if (SelectedCinema != null)
        {
            await _firebaseService.DeleteDataAsync("cinemas", SelectedCinema.CinemaId);
            LoadCinemas();
        }
    }

    protected void OnPropertyChanged(string propertyName) =>
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}