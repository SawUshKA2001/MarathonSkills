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
using MarathonSkillsLibrary;
using MarathonSkills.Controllers;

namespace MarathonSkills.Views.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для AdminEditCharityPage.xaml
    /// </summary>
    public partial class AdminEditCharityPage : Page
    {
        CharitiesController charObj = new CharitiesController();
        FileManagerClass fileObj = new FileManagerClass();
        StringCheckClass strObj = new StringCheckClass();
        byte[] charityImage;
        charities charity;
        /// <summary>
        /// Инициализация страницы AdminEditCharityPage
        /// </summary>
        /// <param name="currentCharity">
        /// Данные изменяемой благотворительной организации
        /// </param>
        public AdminEditCharityPage(charities currentCharity)
        {
            InitializeComponent();

            charity = currentCharity;
            NameTextBox.Text = currentCharity.charity_name;
            DescriptionTextBox.Text = currentCharity.charity_description;
            if (currentCharity.charity_logo != null)
            {
                AvatarImage.Source = FileManagerClass.GetBytePhotoToImage(currentCharity.charity_logo);
                charityImage = currentCharity.charity_logo;
            }

        }

        private void SearchPhotoButton_Click(object sender, RoutedEventArgs e)
        {
            PhotoPathTextBox.Text = fileObj.GetPhotoPath();
            charityImage = fileObj.GetBytePhoto(PhotoPathTextBox.Text);
            if (!String.IsNullOrWhiteSpace(PhotoPathTextBox.Text))
            {
                AvatarImage.Source = FileManagerClass.GetPhotoImage(PhotoPathTextBox.Text);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            string errors = SetBorders();
            if(errors == String.Empty)
            {
                try
                {
                    if (charObj.EditCharity(charityImage, NameTextBox.Text, DescriptionTextBox.Text, charity))
                    {
                        MessageBox.Show("Информация обновлена!");
                        this.NavigationService.GoBack();
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show(errors);
            }
        }

        private string SetBorders()
        {
            NameTextBox.BorderBrush = Brushes.Black;
            NameTextBox.BorderThickness = new Thickness(1);
            DescriptionTextBox.BorderBrush = Brushes.Black;
            DescriptionTextBox.BorderThickness = new Thickness(1);

            string errorString = String.Empty;
            if (String.IsNullOrWhiteSpace(NameTextBox.Text)
                || !strObj.NameCheck(NameTextBox.Text))
            {
                NameTextBox.BorderBrush = Brushes.Red;
                NameTextBox.BorderThickness = new Thickness(3);
                errorString += "Проверьте правильность написания Имени\n";
            }
            if (String.IsNullOrWhiteSpace(DescriptionTextBox.Text)
                || !strObj.NameCheck(DescriptionTextBox.Text))
            {
                DescriptionTextBox.BorderBrush = Brushes.Red;
                DescriptionTextBox.BorderThickness = new Thickness(3);
                errorString += "Проверьте правильность написания Фамилии\n";
            }
            return errorString;
        }
    }
}
