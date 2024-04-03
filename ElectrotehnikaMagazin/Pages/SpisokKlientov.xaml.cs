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
    /// Логика взаимодействия для SpisokKlientov.xaml
    /// </summary>
    public partial class SpisokKlientov : Page
    {
        public SpisokKlientov()
        {
            InitializeComponent();
            var context = Electrotehnika.GetContext();
            var klienty = context.Klienty.ToList();

           
            var klientyWithContactInfo = klienty.Select(k => new {
                ID_Klienta = k.ID_Klienta,
                Familiya = k.Familiya,
                Imya = k.Imya,
                Otchestvo = k.Otchestvo,
                Kontaktnye_dannye = k.Kontaktnye_dannye.ToString() 
            }).ToList();

            lvKlienty.ItemsSource = klientyWithContactInfo;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditKlienty(0));
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            var klienty = lvKlienty.SelectedItem as dynamic;
            int id = klienty.ID_Klienta;
            try
            {
                var context = Electrotehnika.GetContext();
                var klientToRemove = context.Klienty.Find(id);
                context.Klienty.Remove(klientToRemove);
                context.SaveChanges();
                MessageBox.Show("Удаление завершено");

                // Обновляем список клиентов посл удаления
                lvKlienty.ItemsSource = context.Klienty.Select(k => new {
                    ID_Klienta = k.ID_Klienta,
                    Familiya = k.Familiya,
                    Imya = k.Imya,
                    Otchestvo = k.Otchestvo,
                    Kontaktnye_dannye = k.Kontaktnye_dannye.ToString()
                }).ToList();
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
                var klienty = lvKlienty.SelectedItem as dynamic;
                int id = klienty.ID_Klienta;
                NavigationService.Navigate(new EditKlienty(id));

                // Обновляем список клиентов посл редактирования
                var context = Electrotehnika.GetContext();
                lvKlienty.ItemsSource = context.Klienty.Select(k => new {
                    ID_Klienta = k.ID_Klienta,
                    Familiya = k.Familiya,
                    Imya = k.Imya,
                    Otchestvo = k.Otchestvo,
                    Kontaktnye_dannye = k.Kontaktnye_dannye.ToString()
                }).ToList();
            }
        }
    }
}
