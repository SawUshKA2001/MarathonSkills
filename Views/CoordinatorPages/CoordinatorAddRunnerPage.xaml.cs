using MarathonSkills.Controllers;
using MarathonSkillsLibrary;
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

namespace MarathonSkills.Views.CoordinatorPages
{
    /// <summary>
    /// Логика взаимодействия для CoordinatorAddRunnerPage.xaml
    /// </summary>
    public partial class CoordinatorAddRunnerPage : Page
    {
        readonly GendersController genObj = new GendersController();
        readonly CountriesController countryObj = new CountriesController();
        readonly CharitiesController charObj = new CharitiesController();
        readonly UsersController userObj = new UsersController();
        readonly RunnersController runObj = new RunnersController();
        readonly FileManagerClass fileObj = new FileManagerClass();
        readonly StringCheckClass strObj = new StringCheckClass();

        byte[] runnerImage;

        /// <summary>
        /// Инициализация страницы RunnerRegistrationPage
        /// </summary>
        public CoordinatorAddRunnerPage()
        {
            InitializeComponent();

            GenderComboBox.ItemsSource = genObj.GetGenders();
            GenderComboBox.DisplayMemberPath = "gender_name";
            GenderComboBox.SelectedValuePath = "gender_code";
            GenderComboBox.SelectedIndex = 0;

            CountryComboBox.ItemsSource = countryObj.GetCountries();
            CountryComboBox.DisplayMemberPath = "country_name";
            CountryComboBox.SelectedValuePath = "country_id";
            CountryComboBox.SelectedIndex = 0;

            CharityComboBox.ItemsSource = charObj.GetCharities();
            CharityComboBox.DisplayMemberPath = "charity_name";
            CharityComboBox.SelectedValuePath = "charity_id";
            CharityComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Нажатие на кнопку добавления фотографии пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            PhotoPathTextBox.Text = fileObj.GetPhotoPath();
            runnerImage = fileObj.GetBytePhoto(PhotoPathTextBox.Text);
            if (!String.IsNullOrWhiteSpace(PhotoPathTextBox.Text))
            {
                AvatarImage.Source = FileManagerClass.GetPhotoImage(PhotoPathTextBox.Text);
            }
        }

        /// <summary>
        /// Нажатие на кнопку назад
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        /// <summary>
        /// Нажатие на кнопку регистрации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            if (Registration())
            {
                MessageBox.Show("Добавление прошло успешно!");
                this.NavigationService.Navigate(new CoordinatorRunnersPage());
            }
        }

        /// <summary>
        /// Регистрация бегуна
        /// </summary>
        /// <returns>
        /// true - если регистрация успешна
        /// false - если регистрация не успешна
        /// </returns>
        private bool Registration()
        {
            string errorString = SetBorders();
            if (String.IsNullOrEmpty(errorString))
            {
                try
                {
                    bool result = runObj.AddNewRunner(
                        Convert.ToDateTime(BirthDatePicker.SelectedDate),
                        runnerImage,
                        userObj.AddUser(
                        EmailTextBox.Text,
                        FirstNameTextBox.Text,
                        LastNameTextBox.Text,
                        OtherNameTextBox.Text,
                        GenderComboBox.SelectedValue.ToString(),
                        3,
                        PasswordPasswordBox.Password),
                        Convert.ToInt32(CountryComboBox.SelectedValue),
                        Convert.ToInt32(CharityComboBox.SelectedValue));

                    return true;

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else
            {
                MessageBox.Show(errorString);
                return false;
            }
        }

        /// <summary>
        /// Обновление границ заполняемых полей
        /// </summary>
        /// <returns>
        /// Информация о незаполненых полях
        /// </returns>
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
    }
}
