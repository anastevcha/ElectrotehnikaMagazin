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
using ElectrotehnikaMagazin.Model2;

namespace ElectrotehnikaMagazin.Pages
{
    /// <summary>
    /// Логика взаимодействия для Avtorizacia.xaml
    /// </summary>
    public partial class Avtorizacia : Page
    {
        public Avtorizacia()
        {
            InitializeComponent();
            Electrotehnika.GetContext();
        }

        private void btnEnterPokupatel_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Gost());
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            string inputLogin = txtbLogin.Text.Trim();
            string inputParol = pswbPassword.Password.Trim();
            var context = Electrotehnika.GetContext();
            var user = context.Users.Where(u => u.login == inputLogin && u.parol == inputParol).FirstOrDefault();//получение записи о User-е
            if (user != null)
            {
                var sotrudnik = context.Sotrudniki.Where(s => s.ID_Sotrudnika == user.ID_Sotrudnika).FirstOrDefault();//получение id сотрудника в таблице Sotrudniki
                int doljnost = sotrudnik.Doljnost;//получение кода должности
                LoadPage(doljnost);
            }
            else
            {
                MessageBox.Show("Пользователя не существует");
            }
        }
        private void LoadPage(int id)
        {
            if (id == 3) NavigationService.Navigate(new Administrator());
            if (id == 2) NavigationService.Navigate(new Prodavec());
        }
    }
}
