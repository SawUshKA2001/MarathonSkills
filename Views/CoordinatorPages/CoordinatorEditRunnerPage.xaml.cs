using MarathonSkills.Models;
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

namespace MarathonSkills.Views.CoordinatorPages
{
    /// <summary>
    /// Логика взаимодействия для CoordinatorEditRunnerPage.xaml
    /// </summary>
    public partial class CoordinatorEditRunnerPage : Page
    {
        byte[] runnerImage;
        FileManagerClass fileObj = new FileManagerClass();
        StringCheckClass strObj = new StringCheckClass();
        GendersController genObj = new GendersController();
        CountriesController countryObj = new CountriesController();
        RunnersController runObj = new RunnersController();
        public CoordinatorEditRunnerPage(runners currentRunner)
        {
            InitializeComponent();
            EmailTextBox.Text = currentRunner.users.user_email;
            FirstNameTextBox.Text = currentRunner.users.user_firstname;
            LastNameTextBox.Text = currentRunner.users.user_lastname;
            OtherNameTextBox.Text = currentRunner.users.user_othername;

            BirthDatePicker.SelectedDate = currentRunner.runner_birthdate;
            runnerImage = currentRunner.runner_image;
            if (runnerImage != null)
            {
                AvatarImage.Source = FileManagerClass.GetBytePhotoToImage(runnerImage);
            }

            GenderComboBox.ItemsSource = genObj.GetGenders();
            GenderComboBox.DisplayMemberPath = "gender_name";
            GenderComboBox.SelectedValuePath = "gender_code";
            GenderComboBox.SelectedValue = currentRunner.users.gender_code;

            CountryComboBox.ItemsSource = countryObj.GetCountries();
            CountryComboBox.DisplayMemberPath = "country_name";
            CountryComboBox.SelectedValuePath = "country_id";
            CountryComboBox.SelectedValue = currentRunner.country_id;
        }

        private void SearchPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            PhotoPathTextBox.Text = fileObj.GetPhotoPath();
            runnerImage = fileObj.GetBytePhoto(PhotoPathTextBox.Text);
            if (!String.IsNullOrWhiteSpace(PhotoPathTextBox.Text))
            {
                AvatarImage.Source = FileManagerClass.GetPhotoImage(PhotoPathTextBox.Text);
            }
        }

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

                string password = null;

                bool result = runObj.UpdateRunnerInfo(EmailTextBox.Text, firstname, lastname, othername, genderCode, birthdate, countryId, runnerImage, password);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
