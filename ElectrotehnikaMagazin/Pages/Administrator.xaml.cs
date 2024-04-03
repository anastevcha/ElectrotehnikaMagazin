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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ElectrotehnikaMagazin.Pages
{
    /// <summary>
    /// Логика взаимодействия для Administrator.xaml
    /// </summary>
    public partial class Administrator : Page
    {
        public Administrator()
        {
            InitializeComponent();
        }

        private void btnSotrudniki_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SpisokSotrudnikov());
        }

        private void btnTovary_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SpisokTovarov());
        }

        private void btnKlienty_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new SpisokKlientov());
        }
    }
}
