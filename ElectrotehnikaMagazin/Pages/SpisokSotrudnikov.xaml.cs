using ElectrotehnikaMagazin.Model2;
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

using System.Runtime.Remoting.Contexts;

namespace ElectrotehnikaMagazin.Pages
{
    /// <summary>
    /// Логика взаимодействия для SpisokSotrudnikov.xaml
    /// </summary>
    public partial class SpisokSotrudnikov : Page
    {
        public SpisokSotrudnikov()
        {
            InitializeComponent();
            var context = Electrotehnika.GetContext();

            var sotrudniki = context.Sotrudniki
                 .Select(e => new { ID_Sotrudnika = e.ID_Sotrudnika, Imya = e.Imya, Familiya = e.Familiya, Otchestvo = e.Otchestvo, Doljnost = context.Doljnost_Sotrudnika.FirstOrDefault(k => k.ID_Doljnosti == e.Doljnost).Doljnost_Sotrudnika1 })
                 .ToList();

            lvSotrudniki.ItemsSource = sotrudniki;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditSotrudniki(0));
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            var sotr = lvSotrudniki.SelectedItem as dynamic;
            int id = sotr.ID_Sotrudnika;
            try
            {
                var users = Electrotehnika.GetContext().Sotrudniki.Find(id);
                Electrotehnika.GetContext().Sotrudniki.Remove(users);
                Electrotehnika.GetContext().SaveChanges();
                MessageBox.Show("Удаление завершено");
                Electrotehnika.GetContext();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void myListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                var sotr = lvSotrudniki.SelectedItem as dynamic;
                int id = sotr.ID_Sotrudnika;
                NavigationService.Navigate(new EditSotrudniki(id));
            }
        }
    }
}
