using MarathonSkills.Controllers;
using MarathonSkills.Models;
using MarathonSkillsLibrary;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MarathonSkills.Views.RunnerPages
{
    /// <summary>
    /// Логика взаимодействия для RunnerEditProfilePage.xaml
    /// </summary>
    public partial class RunnerEditProfilePage : Page
    {
        readonly RunnersController runObj = new RunnersController();
        readonly UsersController userObj = new UsersController();
        readonly GendersController genObj = new GendersController();
        readonly CountriesController countryObj = new CountriesController();
        readonly FileManagerClass fileObj = new FileManagerClass();
        readonly StringCheckClass strObj = new StringCheckClass();
        readonly users currentUser = new users();
        readonly runners currentRunner = new runners();
        byte[] runnerImage;

        /// <summary>
        /// Инициализация элементов страницы RunnerEditProfilePage
        /// </summary>
        public RunnerEditProfilePage()
        {
            InitializeComponent();

            currentUser = userObj.GetUserInfo(Manager.CurrentUser);
            currentRunner = runObj.GetRunnerInfo(runObj.GetRunnerId(userObj.GetUserId(Manager.CurrentUser)));

            GenderComboBox.ItemsSource = genObj.GetGenders();
            GenderComboBox.DisplayMemberPath = "gender_name";
            GenderComboBox.SelectedValuePath = "gender_code";
            GenderComboBox.SelectedValue = currentUser.gender_code;

            CountryComboBox.ItemsSource = countryObj.GetCountries();
            CountryComboBox.DisplayMemberPath = "country_name";
            CountryComboBox.SelectedValuePath = "country_id";
            CountryComboBox.SelectedValue = currentRunner.country_id;

            BirthDatePicker.SelectedDate = currentRunner.runner_birthdate;

            EmailTextBox.Text = currentUser.user_email;

            FirstNameTextBox.Text = currentUser.user_firstname;
            LastNameTextBox.Text = currentUser.user_lastname;
            OtherNameTextBox.Text = currentUser.user_othername;

            runnerImage = currentRunner.runner_image;

            AvatarImage.Source = FileManagerClass.GetBytePhotoToImage(currentRunner.runner_image);
        }

        /// <summary>
        /// Нажатие на кнопку отмена
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        /// <summary>
        /// Нажатие на кнопку получения фотографии пользователя
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
        /// Нажатие на кнопку сохранения 
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
        /// Обновление данных о бегуне
        /// </summary>
        private void UpdateRunnerInfo()
        {
            try
            {
                string firstname = FirstNameTextBox.Text;
                string lastname = LastNameTextBox.Text;
                string othername = OtherNameTextBox.Text;
                string genderCode = GenderComboBox.SelectedValue.ToString();

                DateTime birthdate = Convert.ToDateTime(BirthDatePicker.SelectedDate);
                int countryId = Convert.ToInt32(CountryComboBox.SelectedValue);

                string password = PasswordPasswordBox.Password;

                bool result = runObj.UpdateRunnerInfo(Manager.CurrentUser, firstname, lastname, othername, genderCode, birthdate, countryId, runnerImage, password);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            if (!String.IsNullOrWhiteSpace(PasswordPasswordBox.Password))
            {
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
