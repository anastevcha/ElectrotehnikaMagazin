using ElectrotehnikaMagazin.Model2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Data.Entity;


namespace ElectrotehnikaMagazin.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditSotrudniki.xaml
    /// </summary>
    public partial class EditSotrudniki : Page
    {
        public Sotrudniki sotrudnik;
        public Electrotehnika context;
        public EditSotrudniki(int id)
        {
            InitializeComponent();
            btnAdd.Visibility = Visibility.Collapsed;
            btnSave.Visibility = Visibility.Collapsed;

            context = Electrotehnika.GetContext();

            // Заполнение ComboBox категориями товаров
            cmbDoljnost.ItemsSource = context.Doljnost_Sotrudnika.ToList();
            cmbDoljnost.DisplayMemberPath = "Doljnost_Sotrudnika1";

            // Добавление значений в ComboBox для поля "Пол"
            cmbPol.Items.Add("Мужской");
            cmbPol.Items.Add("Женский");

            if (id != 0)
            {
                btnSave.Visibility = Visibility.Visible;

                sotrudnik = context.Sotrudniki.Where(s => s.ID_Sotrudnika == id).FirstOrDefault();

                if (sotrudnik != null)
                {
                    txbImya.Text = sotrudnik.Imya;
                    txbFamiliya.Text = sotrudnik.Familiya;
                    txbOtchestvo.Text = sotrudnik.Otchestvo;

                    // Установка значения поля "Пол"
                    if (sotrudnik.Pol == 1)
                        cmbPol.SelectedItem = "Мужской";
                    else if (sotrudnik.Pol == 2)
                        cmbPol.SelectedItem = "Женский";

                    cmbDoljnost.SelectedItem = context.Doljnost_Sotrudnika.FirstOrDefault(k => k.ID_Doljnosti == sotrudnik.Doljnost).Doljnost_Sotrudnika1;
                }
            }
            else
            {
                btnAdd.Visibility = Visibility.Visible;
            }
        }

        private string GetPol(int id)
        {
            string pol = "";
            if (id == 1) pol = "Мужской";
            else if (id == 2) pol = "Женский";
            return pol;
        }
        private int GetPolID(string pol)
        {
            int id = 0;
            if (pol == "Мужской") id = 1;
            else if (pol == "Женский") id = 2;
            else
            {
                MessageBox.Show("Такого пола не существует");
            }
            return id;
        }
        private string IsFIO(string str)
        {
            Regex formatFIO = new Regex("[а-яА-Я]");
            if (formatFIO.Match(str).Success)
            {
                return str;
            }
            else
            {
                MessageBox.Show("Используйте кириллицу, без дополнительных символов!");
                return "";
            }
        }


        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                sotrudnik.Familiya = IsFIO(txbFamiliya.Text);
                sotrudnik.Imya = IsFIO(txbImya.Text);
                sotrudnik.Otchestvo = IsFIO(txbOtchestvo.Text);
                string selectedPol = cmbPol.SelectedItem.ToString();
                if (selectedPol == "Мужской")
                {
                    sotrudnik.Pol = 1;
                }
                else if (selectedPol == "Женский")
                {
                    sotrudnik.Pol = 2;
                }

                Doljnost_Sotrudnika selectedDoljnost = cmbDoljnost.SelectedItem as Doljnost_Sotrudnika;
                if (selectedDoljnost != null)
                {
                    sotrudnik.Doljnost = selectedDoljnost.ID_Doljnosti;
                }

                context.Entry(sotrudnik).State = EntityState.Modified;
                context.SaveChanges();
                MessageBox.Show("Данные изменены");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Sotrudniki sotrudnik = new Sotrudniki();
                var context = Electrotehnika.GetContext();

                // Проверка на корректность введенных данных в поля Фамилия, Имя и Отчество
                if (IsFIO(txbFamiliya.Text) != null && IsFIO(txbImya.Text) != null && IsFIO(txbOtchestvo.Text) != null)
                {
                    sotrudnik.ID_Sotrudnika = new Random().Next(300, 1000);
                    sotrudnik.Familiya = IsFIO(txbFamiliya.Text);
                    sotrudnik.Imya = IsFIO(txbImya.Text);
                    sotrudnik.Otchestvo = IsFIO(txbOtchestvo.Text);

                    // Установка значения поля "Пол" на основе выбранного элемента в ComboBox
                    if (cmbPol.SelectedItem != null)
                    {
                        string selectedPol = cmbPol.SelectedItem.ToString();
                        if (selectedPol == "Мужской")
                        {
                            sotrudnik.Pol = 1;
                        }
                        else if (selectedPol == "Женский")
                        {
                            sotrudnik.Pol = 2;
                        }
                    }

                    // Получаем выбранную должность из ComboBox и устанавливаем ее для нового сотрудника
                    Doljnost_Sotrudnika selectedDoljnost = cmbDoljnost.SelectedItem as Doljnost_Sotrudnika;
                    if (selectedDoljnost != null)
                    {
                        sotrudnik.Doljnost = selectedDoljnost.ID_Doljnosti;
                    }

                    if (context != null)
                    {
                        context.Sotrudniki.Add(sotrudnik);
                        context.SaveChanges();
                        MessageBox.Show("Сотрудник добавлен");
                    }
                    else
                    {
                        MessageBox.Show("Ошибка при добавлении сотрудника. Повторите попытку.");
                    }
                }
                else
                {
                    MessageBox.Show("Проверьте корректность введенных данных в полях Фамилия, Имя и Отчество.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message);
            }
        }
    }
}
