using System.Windows;
using CineMultisalas.Views;

namespace CineMultisalas.Views
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            
            string user = txtUser.Text;
            string password = txtPassword.Password;

            // Validar con la base de datos
            if (user == "admin" && password == "1234")
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