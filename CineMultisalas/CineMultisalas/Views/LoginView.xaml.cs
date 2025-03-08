using System.Windows;
using CineMultisalas.ViewModels;

namespace CineMultisalas.Views
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            // Se obtiene el ViewModel desde el DataContext
            var viewModel = (LoginViewModel)DataContext;

            // Valida el usuario y la contraseña de manera asíncrona
            if (await viewModel.Authenticate(txtUser.Text, txtPassword.Password))
            {
                MessageBox.Show("Login exitoso");

                var homeView = new HomeView();
                homeView.Show();

                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }
    }
}