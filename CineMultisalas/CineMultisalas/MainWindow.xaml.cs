using System.Windows;
using CineMultisalas.Views;

namespace CineMultisalas
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Abre el login al iniciar la aplicación
            var loginView = new LoginView();
            loginView.Show();

            this.Close();
        }
    }
}