using CineMultisalas.Models;
using CineMultisalas.Services;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace CineMultisalas.ViewModels
{
    internal class FunctionsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Function> _functions;
        private readonly FirebaseService _firebaseService;

        public ObservableCollection<Function> Functions
        {
            get => _functions;
            set
            {
                _functions = value;
                OnPropertyChanged(nameof(Functions));
            }
        }

        public ICommand AddFunctionCommand { get; }
        public ICommand EditFunctionCommand { get; }
        public ICommand DeleteFunctionCommand { get; }

        public FunctionsViewModel()
        {
            _firebaseService = new FirebaseService();
            LoadFunctions();
            AddFunctionCommand = new RelayCommand(OnAddFunction);
            EditFunctionCommand = new RelayCommand(OnEditFunction);
            DeleteFunctionCommand = new RelayCommand(OnDeleteFunction);
        }

        private async void LoadFunctions()
        {
            // Cargar funciones desde Firebase
            var functions = await _firebaseService.GetDataAsync<Function>("functions");
            Functions = new ObservableCollection<Function>(functions);
        }

        private async void OnAddFunction()
        {
            // Lógica para añadir una nueva función
            var newFunction = new Function
            {
                FilmId = 1, // Ejemplo: ID de la película
                CinemaId = 1, // Ejemplo: ID de la sala
                StartTime = DateTime.Now, // Ejemplo: Hora de inicio
                EndTime = DateTime.Now.AddHours(2) // Ejemplo: Hora de finalización
            };

            await _firebaseService.AddDataAsync("functions", newFunction);
            LoadFunctions(); // Recargar la lista de funciones
        }

        private async void OnEditFunction()
        {
            // Lógica para editar una función existente
            if (Functions.Count > 0)
            {
                var functionToEdit = Functions[0]; // Ejemplo: Selecciona la primera función
                functionToEdit.StartTime = DateTime.Now.AddHours(1); // Ejemplo: Cambiar la hora de inicio

                await _firebaseService.UpdateDataAsync("functions", functionToEdit.FunctionId.ToString(), functionToEdit);
                LoadFunctions(); // Recargar la lista de funciones
            }
        }

        private async void OnDeleteFunction()
        {
            // Lógica para eliminar una función
            if (Functions.Count > 0)
            {
                var functionToDelete = Functions[0]; // Ejemplo: Selecciona la primera función
                await _firebaseService.DeleteDataAsync("functions", functionToDelete.FunctionId.ToString());
                LoadFunctions(); // Recargar la lista de funciones
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}