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
    /// Логика взаимодействия для EditTovara.xaml
    /// </summary>
    public partial class EditTovara : Page
    {
        public Tovary tovary;
        public Electrotehnika context;
        public EditTovara(int id)
        {
            InitializeComponent();
            btnAdd.Visibility = Visibility.Collapsed;
            btnSave.Visibility = Visibility.Collapsed;

            context = Electrotehnika.GetContext();

            // Заполнение ComboBox категориями товаров
            cmbCategories.ItemsSource = context.Kategorii_Tovarov.ToList();
            cmbCategories.DisplayMemberPath = "Naimenovanie";

            if (id != 0)
            {
                btnSave.Visibility = Visibility.Visible;

                tovary = context.Tovary.Where(s => s.ID_Tovara == id).FirstOrDefault();

                if (tovary != null)
                {
                    txbNaimenovanie.Text = tovary.Naimenovanie_Tovara;
                    txbOpisanie.Text = tovary.Opisanie_Tovara;

                    cmbCategories.SelectedItem = context.Kategorii_Tovarov.FirstOrDefault(k => k.ID_Kategorii == tovary.Kategoriya_Tovara);
                }
            }
            else
            {
                btnAdd.Visibility = Visibility.Visible;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbNaimenovanie.Text) || string.IsNullOrWhiteSpace(txbOpisanie.Text) || cmbCategories.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, заполните все поля перед сохранением.");
                return;
            }

            if (tovary == null)
            {
                tovary = new Tovary();
                context.Tovary.Add(tovary);
            }

            tovary.Naimenovanie_Tovara = txbNaimenovanie.Text;
            tovary.Opisanie_Tovara = txbOpisanie.Text;

            Kategorii_Tovarov selectedCategory = (Kategorii_Tovarov)cmbCategories.SelectedItem;
            tovary.Kategoriya_Tovara = selectedCategory.ID_Kategorii;

            context.SaveChanges();

            MessageBox.Show("Данные успешно сохранены.");
        }


        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (cmbCategories.SelectedItem != null && !string.IsNullOrWhiteSpace(txbNaimenovanie.Text))
            {
                Random random = new Random();
                int randomID = random.Next(300, 1001); // Генерация случайного числа от 300 до 1000

                Tovary newTovar = new Tovary
                {
                    ID_Tovara = randomID,
                    Naimenovanie_Tovara = txbNaimenovanie.Text,
                    Opisanie_Tovara = txbOpisanie.Text,
                    Kategoriya_Tovara = (cmbCategories.SelectedItem as Kategorii_Tovarov).ID_Kategorii
                };

                context.Tovary.Add(newTovar);
                context.SaveChanges();

                MessageBox.Show("Товар успешно добавлен.");
            }
            else
            {
                MessageBox.Show("Пожалуйста, заполните все поля перед добавлением товара.");
            }
        }
    }

}

