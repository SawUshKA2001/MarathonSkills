using MarathonSkills.Controllers;
using MarathonSkills.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace MarathonSkills.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
            Manager.CurrentUser = String.Empty;
        }

        private void SeePasswordButton_Click(object sender, RoutedEventArgs e)
        {
            if (VisiblePasswordStackPanel.Visibility == Visibility.Collapsed)
            {
                VisiblePasswordStackPanel.Visibility = Visibility.Visible;
                PasswordTextBox.Text = PasswordPasswordBox.Password;
                HiddenPasswordStackPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                HiddenPasswordStackPanel.Visibility = Visibility.Visible;
                PasswordPasswordBox.Password = PasswordTextBox.Text;
                VisiblePasswordStackPanel.Visibility = Visibility.Collapsed;
            }
        }

        readonly UsersController objUser = new UsersController();

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            string userPassword;
            if (VisiblePasswordStackPanel.Visibility == Visibility.Collapsed)
            {
                userPassword = PasswordPasswordBox.Password;
            }
            else
            {
                userPassword = PasswordTextBox.Text;
            }
            switch (objUser.UserAuth(EmailTextBox.Text, userPassword))
            {
                case 0:
                    MessageBox.Show("Авторизационные данные введены не верно!");
                    break;
                case 1:
                    this.NavigationService.Navigate(new AdminPages.AdminMenuPage());
                    break;
                case 2:
                    this.NavigationService.Navigate(new CoordinatorPages.CoordinatorMenuPage());
                    break;
                case 3:
                    this.NavigationService.Navigate(new RunnerPages.RunnerMenuPage());
                    break;
                case 4:
                    this.NavigationService.Navigate(new ViewerPages.ViewerMenuPage());
                    break;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }
    }
}
