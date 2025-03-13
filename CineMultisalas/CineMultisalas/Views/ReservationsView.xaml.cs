using CineMultisalas.ViewModels;
using System.Windows;

namespace CineMultisalas.Views
{
    public partial class ReservationsView : Window
    {
        // Constructor sin parámetros (carga todas las reservas)
        public ReservationsView()
        {
            InitializeComponent();
            DataContext = new ReservationsViewModel(); 
        }

        
    }
}