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
using MarathonSkills.Controllers;
using MarathonSkillsLibrary;

namespace MarathonSkills.Views.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для AdminAddVolunteerPage.xaml
    /// </summary>
    public partial class AdminAddVolunteerPage : Page
    {
        StringCheckClass strObj = new StringCheckClass();
        VolunteersController volObj = new VolunteersController();
        GendersController genObj = new GendersController();
        CountriesController countryObj = new CountriesController();
        /// <summary>
        /// Инициализация страницы AdminAddVolunteerPage
        /// </summary>
        public AdminAddVolunteerPage()
        {
            InitializeComponent();

            GenderComboBox.ItemsSource = genObj.GetGenders();
            GenderComboBox.SelectedValuePath = "gender_code";
            GenderComboBox.DisplayMemberPath = "gender_name";
            GenderComboBox.SelectedIndex = 0;

            CountryComboBox.ItemsSource = countryObj.GetCountries();
            CountryComboBox.SelectedValuePath = "country_id";
            CountryComboBox.DisplayMemberPath = "country_name";
            CountryComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Нажатие на кнопку добаления волонтёра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string errors = SetBorders();
            if (errors == String.Empty)
            {
                try
                {
                    if (
                        volObj.AddNewVolunteer(
                        FirstNameTextBox.Text, 
                        LastNameTextBox.Text, 
                        OtherNameTextBox.Text, 
                        Convert.ToDateTime(BirthDatePicker.SelectedDate), 
                        Convert.ToInt32(CountryComboBox.SelectedValue), 
                        GenderComboBox.SelectedValue.ToString())
                        )
                    {
                        MessageBox.Show("Данные успешно добавлены!");
                        this.NavigationService.Navigate(new VolunteersPage());
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show(errors);
            }
        }

        /// <summary>
        /// Обновление границ заполняемых полей
        /// </summary>
        /// <returns>
        /// Список ошибок незаполненных полей
        /// </returns>
        private string SetBorders()
        {
            FirstNameTextBox.BorderBrush = Brushes.Black;
            FirstNameTextBox.BorderThickness = new Thickness(1);
            LastNameTextBox.BorderBrush = Brushes.Black;
            LastNameTextBox.BorderThickness = new Thickness(1);
            OtherNameTextBox.BorderBrush = Brushes.Black;
            OtherNameTextBox.BorderThickness = new Thickness(1);


            string errorString = String.Empty;
            if (String.IsNullOrWhiteSpace(FirstNameTextBox.Text)
                || !strObj.NameCheck(FirstNameTextBox.Text))
            {
                FirstNameTextBox.BorderBrush = Brushes.Red;
                FirstNameTextBox.BorderThickness = new Thickness(3);
                errorString += "Проверьте правильность написания Имени\n";
            }
            if (String.IsNullOrWhiteSpace(LastNameTextBox.Text)
                || !strObj.NameCheck(LastNameTextBox.Text))
            {
                LastNameTextBox.BorderBrush = Brushes.Red;
                LastNameTextBox.BorderThickness = new Thickness(3);
                errorString += "Проверьте правильность написания Фамилии\n";
            }
            if (String.IsNullOrWhiteSpace(OtherNameTextBox.Text)
                || !strObj.NameCheck(OtherNameTextBox.Text))
            {
                OtherNameTextBox.BorderBrush = Brushes.Red;
                OtherNameTextBox.BorderThickness = new Thickness(3);
                errorString += "Проверьте правильность написания Отчества\n";
            }
            return errorString;
        }
    }
}
