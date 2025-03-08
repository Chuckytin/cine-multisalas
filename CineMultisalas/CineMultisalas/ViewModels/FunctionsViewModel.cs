using CineMultisalas.Models;
using CineMultisalas.Services;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace CineMultisalas.ViewModels
{
    internal class FunctionsViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Function> _functions;
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
            LoadFunctions();
            AddFunctionCommand = new RelayCommand(OnAddFunction);
            EditFunctionCommand = new RelayCommand(OnEditFunction);
            DeleteFunctionCommand = new RelayCommand(OnDeleteFunction);
        }

        private async void LoadFunctions()
        {
            // Cargar funciones desde DatabaseService
            var databaseService = new DatabaseService("YourConnectionString");
            var functions = await databaseService.GetFunctionsAsync();
            Functions = new ObservableCollection<Function>(functions);
        }

        private void OnAddFunction()
        {
            // Lógica para añadir una nueva función
        }

        private void OnEditFunction()
        {
            // Lógica para editar una función existente
        }

        private void OnDeleteFunction()
        {
            // Lógica para eliminar una función
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}