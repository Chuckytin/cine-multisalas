using CineMultisalas.Models;
using CineMultisalas.ViewModels;
using System.Windows;

namespace CineMultisalas.Views
{
    public partial class ReservationsView : Window
    {
        public ReservationsView(int functionId)
        {
            InitializeComponent();
            DataContext = new ReservationsViewModel(functionId); // Pasar el ID de la función
        }
    }
}