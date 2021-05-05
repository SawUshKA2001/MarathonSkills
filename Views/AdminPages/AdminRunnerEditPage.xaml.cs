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
    /// Логика взаимодействия для AdminRunnerEditPage.xaml
    /// </summary>
    public partial class AdminRunnerEditPage : Page
    {
        GendersController genObj = new GendersController();
        CountriesController countryObj = new CountriesController();
        StringCheckClass strObj = new StringCheckClass();
        FileManagerClass fileObj = new FileManagerClass();
        RunnersController runObj = new RunnersController();

        byte[] runnerImage;
        public AdminRunnerEditPage(users currentUser, runners currentRunner)
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

            BirthDatePicker.SelectedDate = currentRunner.runner_birthdate;

            CountryComboBox.ItemsSource = countryObj.GetCountries();
            CountryComboBox.DisplayMemberPath = "country_name";
            CountryComboBox.SelectedValuePath = "country_id";
            CountryComboBox.SelectedValue = currentRunner.country_id;

            runnerImage = currentRunner.runner_image;
            AvatarImage.Source = FileManagerClass.GetBytePhotoToImage(runnerImage);

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

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
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
                string password = null;

                DateTime birthdate = Convert.ToDateTime(BirthDatePicker.SelectedDate);
                int countryId = Convert.ToInt32(CountryComboBox.SelectedValue);

                bool result = runObj.UpdateRunnerInfo(EmailTextBox.Text, firstname, lastname, othername, genderCode, birthdate, countryId, runnerImage, password);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
