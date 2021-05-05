using MarathonSkills.Controllers;
using MarathonSkills.Models;
using MarathonSkillsLibrary;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MarathonSkills.Views.ViewerPages
{
    /// <summary>
    /// Логика взаимодействия для ViewerRegistrationPage.xaml
    /// </summary>
    public partial class ViewerRegistrationPage : Page
    {
        readonly StringCheckClass strObj = new StringCheckClass();
        readonly UsersController userObj = new UsersController();
        readonly GendersController genObj = new GendersController();
        public ViewerRegistrationPage()
        {
            InitializeComponent();
            GenderComboBox.ItemsSource = genObj.GetGenders();
            GenderComboBox.DisplayMemberPath = "gender_name";
            GenderComboBox.SelectedValuePath = "gender_code";
            GenderComboBox.SelectedIndex = 0;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AuthPage());
        }

        private string SetBorders()
        {
            EmailTextBox.BorderBrush = Brushes.Black;
            EmailTextBox.BorderThickness = new Thickness(1);
            PasswordPasswordBox.BorderBrush = Brushes.Black;
            PasswordPasswordBox.BorderThickness = new Thickness(1);
            RepeatPasswordBox.BorderBrush = Brushes.Black;
            RepeatPasswordBox.BorderThickness = new Thickness(1);
            FirstNameTextBox.BorderBrush = Brushes.Black;
            FirstNameTextBox.BorderThickness = new Thickness(1);
            LastNameTextBox.BorderBrush = Brushes.Black;
            LastNameTextBox.BorderThickness = new Thickness(1);
            OtherNameTextBox.BorderBrush = Brushes.Black;
            OtherNameTextBox.BorderThickness = new Thickness(1);

            string errorString = String.Empty;
            if (String.IsNullOrWhiteSpace(EmailTextBox.Text)
                || !strObj.EmailCheck(EmailTextBox.Text))
            {
                EmailTextBox.BorderBrush = Brushes.Red;
                EmailTextBox.BorderThickness = new Thickness(3);
                errorString += "Проверьте правильность написания Email\n";
            }
            if (!userObj.CheckEmailDuplication(EmailTextBox.Text))
            {
                EmailTextBox.BorderBrush = Brushes.Red;
                EmailTextBox.BorderThickness = new Thickness(3);
                errorString += "Пользователь с таким Email уже существует\n";
            }
            if (String.IsNullOrWhiteSpace(PasswordPasswordBox.Password)
                || !strObj.PasswordCheck(PasswordPasswordBox.Password))
            {
                PasswordPasswordBox.BorderBrush = Brushes.Red;
                PasswordPasswordBox.BorderThickness = new Thickness(3);
                errorString += "Проверьте правильность написания пароля\n";
            }
            if (String.IsNullOrWhiteSpace(RepeatPasswordBox.Password)
                || !strObj.PasswordCheck(RepeatPasswordBox.Password))
            {
                RepeatPasswordBox.BorderBrush = Brushes.Red;
                RepeatPasswordBox.BorderThickness = new Thickness(3);
                errorString += "Проверьте правильность написания пароля\n";
            }
            if (PasswordPasswordBox.Password != RepeatPasswordBox.Password)
            {
                PasswordPasswordBox.BorderBrush = Brushes.Red;
                PasswordPasswordBox.BorderThickness = new Thickness(3);
                RepeatPasswordBox.BorderBrush = Brushes.Red;
                RepeatPasswordBox.BorderThickness = new Thickness(3);
                errorString += "Пароли не совпадают\n";
            }
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

        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            string errors = SetBorders();
            if (errors == String.Empty)
            {
                try
                {
                    userObj.AddUser(EmailTextBox.Text, FirstNameTextBox.Text, LastNameTextBox.Text, OtherNameTextBox.Text, GenderComboBox.SelectedValue.ToString(), 4, PasswordPasswordBox.Password);
                    MessageBox.Show("Регистрация прошла успешно!");
                    Manager.CurrentUser = EmailTextBox.Text;
                    this.NavigationService.Navigate(new ViewerMenuPage());

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
    }
}
