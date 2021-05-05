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
using MarathonSkills.Models;
using MarathonSkills.Controllers;
using MarathonSkillsLibrary;

namespace MarathonSkills.Views.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для AdminUserEditPage.xaml
    /// </summary>
    public partial class AdminUserEditPage : Page
    {
        readonly GendersController genObj = new GendersController();
        readonly UsersController userObj = new UsersController();
        readonly StringCheckClass strObj = new StringCheckClass();
        /// <summary>
        /// Инициализация элементов страницы AdminUserEditPage
        /// </summary>
        /// <param name="currentUser">
        /// Полученные данные о пользователе
        /// </param>
        public AdminUserEditPage(users currentUser)
        {
            InitializeComponent();
            EmailTextBox.Text = currentUser.user_email;
            FirstNameTextBox.Text = currentUser.user_firstname;
            LastNameTextBox.Text = currentUser.user_lastname;
            OtherNameTextBox.Text = currentUser.user_othername;

            GenderComboBox.ItemsSource = genObj.GetGenders();
            GenderComboBox.DisplayMemberPath = "gender_name";
            GenderComboBox.SelectedValuePath = "gender_code";
            GenderComboBox.SelectedValue = currentUser.gender_code;
        }

        /// <summary>
        /// Обновление границ заполняемых полей
        /// </summary>
        /// <returns>
        /// Возвращает строку с информацией о незаполненных полях 
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
        /// <summary>
        /// Нажатие на кнопку Отмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
        /// <summary>
        /// Нажатие на кнопку сохранения информации о пользователе
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveProfileButton_Click(object sender, RoutedEventArgs e)
        {
            string errors = SetBorders();
            if (errors == String.Empty)
            {
                UpdateRunnerInfo();
                MessageBox.Show("Профиль успешно отредактирован!");
            }
            else
            {
                MessageBox.Show(errors);
            }
        }

        /// <summary>
        /// Обновление данных о пользователе
        /// </summary>
        private void UpdateRunnerInfo()
        {
            try
            {
                string firstname = FirstNameTextBox.Text;
                string lastname = LastNameTextBox.Text;
                string othername = OtherNameTextBox.Text;
                string genderCode = GenderComboBox.SelectedValue.ToString();
                string password = null;
                bool result = userObj.UpdateUserInfo(EmailTextBox.Text, firstname, lastname, othername, genderCode, password);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
