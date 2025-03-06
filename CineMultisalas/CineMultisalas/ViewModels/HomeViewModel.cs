using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CineMultisalas.Views;
using System.Windows.Input;
using System.Windows;

namespace CineMultisalas.ViewModels
{
    internal class HomeViewModel
    {

        public ICommand IrAPeliculasCommand { get; }
        public ICommand IrASalasCommand { get; }

        public HomeViewModel()
        {
            IrAPeliculasCommand = new RelayCommand(IrAPeliculas);
            IrASalasCommand = new RelayCommand(IrASalas);
        }

        private void IrAPeliculas(object parameter)
        {
            var peliculasView = new PeliculasView();
            peliculasView.Show();
            Application.Current.Windows[0]?.Close(); 
        }

        private void IrASalas(object parameter)
        {
            var salasView = new SalasView();
            salasView.Show();
            Application.Current.Windows[0]?.Close(); 
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
