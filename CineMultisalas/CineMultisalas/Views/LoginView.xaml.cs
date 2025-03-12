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

            var viewModel = (LoginViewModel)DataContext;
            var user = await viewModel.LoginAsync(username, password);

            if (user != null)
            {
                if (user.Role == "Admin")
                {
                    var homeView = new HomeView(true); // Vista de administrador (isAdmin = true)
                    homeView.Show();
                }
                else
                {
                    var functionsView = new FunctionsView(false); // Vista de usuario (isAdmin = false)
                    functionsView.Show();
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }
    }
}