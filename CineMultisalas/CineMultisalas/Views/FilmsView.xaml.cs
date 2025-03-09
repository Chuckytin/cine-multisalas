using CineMultisalas.Helpers;
using CineMultisalas.Models;
using CineMultisalas.Services;
using CineMultisalas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CineMultisalas.Views
{
    public partial class FilmsView : Window
    {
        public FilmsView()
        {
            InitializeComponent();
            DataContext = new FilmsViewModel();
        }

        private void ButtonHelp_Click(object sender, RoutedEventArgs e)
        {
            string helpMessage = ContextualHelps.GetHelp("FilmsView");
            MessageBox.Show(helpMessage, "Ayuda Contextual", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
