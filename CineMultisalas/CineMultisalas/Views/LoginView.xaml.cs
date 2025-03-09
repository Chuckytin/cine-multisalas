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
            var username = txtUser.Text;
            var password = txtPassword.Password;
            System.Diagnostics.Debug.WriteLine($"Usuario: {username}, Contraseña: {password}");

            var viewModel = (LoginViewModel)DataContext;
            var userId = await viewModel.LoginAsync(username, password);
            if (userId != null)
            {
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