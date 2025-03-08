using System.Windows;
using CineMultisalas.ViewModels;

namespace CineMultisalas.Views
{
    public partial class HomeView : Window
    {
        public HomeView()
        {
            InitializeComponent();

            DataContext = new HomeViewModel();
        }
    }
}