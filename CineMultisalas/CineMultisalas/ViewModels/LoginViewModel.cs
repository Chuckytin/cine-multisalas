using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineMultisalas.Services;
using CineMultisalas.Views;
using System.Windows.Input;
using System.Windows;

namespace CineMultisalas.ViewModels
{
    internal class LoginViewModel : INotifyPropertyChanged
    {
        private string _usuario;
        public string Usuario
        {
            get { return _usuario; }
            set
            {
                _usuario = value;
                OnPropertyChanged(nameof(Usuario));
            }
        }

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
        }

        private void Login(object parameter)
        {
            var authService = new AuthService();
            if (authService.ValidarUsuario(Usuario, parameter.ToString()))
            {
                MessageBox.Show("Login exitoso");
                
                var homeView = new HomeView();
                homeView.Show();
                Application.Current.Windows[0]?.Close(); 
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
