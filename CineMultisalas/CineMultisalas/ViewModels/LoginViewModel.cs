using CineMultisalas.Services;
using CineMultisalas.Views;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CineMultisalas.ViewModels
{
    internal class LoginViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private readonly AuthService _authService;

        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            _authService = new AuthService(); // Inicializa el servicio de autenticación
            LoginCommand = new RelayCommand(async () => await OnLogin());
        }

        // Método para autenticar al usuario
        public async Task<bool> Authenticate(string username, string password)
        {
            return await _authService.Authenticate(username, password);
        }

        private async Task OnLogin()
        {
            if (await Authenticate(Username, Password))
            {
                MessageBox.Show("Login exitoso");

                // Navega a la vista principal (HomeView)
                var homeView = new HomeView();
                homeView.Show();

                Application.Current.MainWindow.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}