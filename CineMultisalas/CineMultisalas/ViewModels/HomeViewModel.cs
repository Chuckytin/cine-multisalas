using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CineMultisalas.Views;
using System.Windows;

namespace CineMultisalas.ViewModels
{
    public partial class HomeViewModel : ObservableObject
    {
        [RelayCommand]
        private void IrAPeliculas()
        {
            var peliculasView = new PeliculasView();
            peliculasView.Show();
            Application.Current.Windows[0]?.Close(); 
        }

        [RelayCommand]
        private void IrASalas()
        {
            var salasView = new SalasView();
            salasView.Show();
            Application.Current.Windows[0]?.Close(); 
        }
    }
}