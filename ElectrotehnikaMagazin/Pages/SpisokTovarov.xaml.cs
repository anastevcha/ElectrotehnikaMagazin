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

namespace ElectrotehnikaMagazin.Pages
{
    /// <summary>
    /// Логика взаимодействия для SpisokTovarov.xaml
    /// </summary>
    public partial class SpisokTovarov : Page
    {
        public SpisokTovarov()
        {
            InitializeComponent();
            var context = Electrotehnika.GetContext();
            var tovary = context.Tovary 
                 .Select(e => new { ID_Tovara = e.ID_Tovara, Naimenovanie_Tovara = e.Naimenovanie_Tovara, Opisanie_Tovara = e.Opisanie_Tovara, Kategoriya_Tovara = context.Kategorii_Tovarov.FirstOrDefault(k => k.ID_Kategorii == e.Kategoriya_Tovara).Naimenovanie })
                 .ToList();

            lvTovary.ItemsSource = tovary; 
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditTovara(0));
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            var tovar = lvTovary.SelectedItem as dynamic;
            int id = tovar.ID_Tovara;
            try
            {
                var users = Electrotehnika.GetContext().Tovary.Find(id);
                Electrotehnika.GetContext().Tovary.Remove(users);
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
                var tovar = lvTovary.SelectedItem as dynamic;
                int id = tovar.ID_Tovara;
                NavigationService.Navigate(new EditTovara(id));
            }

        }

        
    }
}
