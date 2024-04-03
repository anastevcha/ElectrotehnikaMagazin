using ElectrotehnikaMagazin.Model2;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Логика взаимодействия для EditKlienty.xaml
    /// </summary>
    public partial class EditKlienty : Page
    {
        public Klienty klienty;
        public Electrotehnika context;
        public EditKlienty(int id)
        {
            InitializeComponent();
            btnAdd.Visibility = Visibility.Collapsed;
            btnSave.Visibility = Visibility.Collapsed;

            context = Electrotehnika.GetContext();

            // Добавление значений в ComboBox для поля "Пол"
            cmbPol.Items.Add("Мужской");
            cmbPol.Items.Add("Женский");
            if (id != 0)
            {
                btnSave.Visibility = Visibility.Visible;
                klienty = Electrotehnika.GetContext().Klienty.Where(s => s.ID_Klienta == id).FirstOrDefault();
                if (klienty!=null)
                {
                    txbFamiliya.Text = klienty.Familiya;
                    txbImya.Text = klienty.Imya;
                    txbOtchestvo.Text = klienty.Otchestvo;
                    txbKontakty.Text = klienty.Kontaktnye_dannye.ToString();
                    // Установка значения поля "Пол"
                    if (klienty.Pol == 1)
                        cmbPol.SelectedItem = "Мужской";
                    else if (klienty.Pol == 2)
                        cmbPol.SelectedItem = "Женский";
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
                klienty.Familiya = IsFIO(txbFamiliya.Text);
                klienty.Imya = IsFIO(txbImya.Text);
                klienty.Otchestvo = IsFIO(txbOtchestvo.Text);

                decimal result;
                if (decimal.TryParse(txbKontakty.Text, out result))
                {
                    klienty.Kontaktnye_dannye = result;

                    // Установка значения поля "Пол" на основе выбранного элемента в ComboBox
                    string selectedPol = cmbPol.SelectedItem.ToString();
                    if (selectedPol == "Мужской")
                    {
                        klienty.Pol = 1;
                    }
                    else if (selectedPol == "Женский")
                    {
                        klienty.Pol = 2;
                    }

                    context.Entry(klienty).State = EntityState.Modified;
                    context.SaveChanges();
                    MessageBox.Show("Данные изменены");
                }
                else
                {
                    MessageBox.Show("Некорректный формат числа");
                }
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
                Klienty klienty = new Klienty();
                var context = Electrotehnika.GetContext();
                klienty.ID_Klienta = new Random().Next(300, 1000);
                klienty.Familiya = IsFIO(txbFamiliya.Text);
                klienty.Imya = IsFIO(txbImya.Text);
                klienty.Otchestvo = IsFIO(txbOtchestvo.Text);
                if (decimal.TryParse(txbKontakty.Text, out decimal result))
                {
                    klienty.Kontaktnye_dannye = result;
                }
                else
                {
                    // Обработка ошибки в случае некорректного ввода
                    MessageBox.Show("Некорректный формат числа");
                }
                // Установка значения поля "Пол" на основе выбранного элемента в ComboBox
                if (cmbPol.SelectedItem != null)
                {
                    string selectedPol = cmbPol.SelectedItem.ToString();
                    if (selectedPol == "Мужской")
                    {
                        klienty.Pol = 1;
                    }
                    else if (selectedPol == "Женский")
                    {
                        klienty.Pol = 2;
                    }
                }
                if (context != null)
                {
                    context.Klienty.Add(klienty);
                    context.SaveChanges();
                    MessageBox.Show("Клиент добавлен");
                }
                else
                {
                    MessageBox.Show("Повторите попытку");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
    
}
