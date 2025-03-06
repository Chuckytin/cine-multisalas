using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CineMultisalas.Services;
using CineMultisalas.Views;
using System.Windows;
using CineMultisalas.Models;

namespace CineMultisalas.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        private string _usuario;

        public LoginViewModel()
        {
        }

        [RelayCommand]
        private void Login(object parameter)
        {
            var authService = new AuthService();
            if (authService.ValidarUsuario(Usuario, parameter.ToString()))
            {
                MessageBox.Show("Login exitoso");

                var homeView = new HomeView();
                homeView.Show();
                Application.Current.Windows[0]?.Close(); // Cierra la ventana de login
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }
    }
}