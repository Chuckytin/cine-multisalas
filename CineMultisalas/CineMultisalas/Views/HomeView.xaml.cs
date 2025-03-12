using System.Windows;
using CineMultisalas.Helpers;
using CineMultisalas.ViewModels;

namespace CineMultisalas.Views
{
    public partial class HomeView : Window
    {

        public HomeView(bool isAdmin)
        {
            InitializeComponent();
            DataContext = new HomeViewModel(isAdmin); // Pasa el parámetro isAdmin
        }

        private void MenuItemLogout_Click(object sender, RoutedEventArgs e)
        {
            // Cierra sesión y vuelve a la ventana de login
            var loginView = new LoginView();
            loginView.Show();
            this.Close();
        }

        private void MenuItemHelp_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Aquí puedes navegar a las diferentes secciones del cine.", "Ayuda");
        }

        private void ButtonHelp_Click(object sender, RoutedEventArgs e)
        {
            string helpMessage = ContextualHelps.GetHelp("HomeView");
            MessageBox.Show(helpMessage, "Ayuda Contextual", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}