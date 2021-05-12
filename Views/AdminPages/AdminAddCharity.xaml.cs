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


namespace MarathonSkills.Views.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для AdminAddCharity.xaml
    /// </summary>
    public partial class AdminAddCharity : Page
    {
        CharitiesController charObj = new CharitiesController();
        FileManagerClass fileObj = new FileManagerClass();
        StringCheckClass strObj = new StringCheckClass();
        byte[] charityImage;
        /// <summary>
        /// Инициализация страницы AdminAddCharity
        /// </summary>
        public AdminAddCharity()
        {
            InitializeComponent();

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
            if (errors == String.Empty)
            {
                try
                {
                    if (charObj.AddNewCharity(charityImage, NameTextBox.Text, DescriptionTextBox.Text))
                    {
                        MessageBox.Show("Благотворительная организация добалена!");
                        this.NavigationService.GoBack();
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
