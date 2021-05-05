using MarathonSkills.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace MarathonSkills.Views
{
    /// <summary>
    /// Логика взаимодействия для NavigationPage.xaml
    /// </summary>
    public partial class NavigationPage : Page
    {
        public NavigationPage(string page)
        {
            InitializeComponent();
            switch (page)
            {
                case "Авторизация":
                    NavigationFrame.Navigate(new AuthPage());
                    break;
                case "Стать бегуном":
                    NavigationFrame.Navigate(new RunnerPages.RunnerRegistrationPage());
                    break;
                case "Пожертвование":
                    NavigationFrame.Navigate(new DonatorPages.DonationPage());
                    break;
                case "Стать зрителем":
                    NavigationFrame.Navigate(new ViewerPages.ViewerRegistrationPage());
                    break;
                case "Узнать больше":
                    NavigationFrame.Navigate(new MoreAboutPages.MoreAboutMenuPage());
                    break;
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.NavigationService.CanGoBack)
            {
                this.NavigationService.GoBack();
            }
        }

        private void NavigationFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (Manager.CurrentUser == String.Empty)
            {
                LogoutButton.Visibility = Visibility.Collapsed;
            }
            else
            {
                LogoutButton.Visibility = Visibility.Visible;
            }
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationFrame.Navigate(new AuthPage());
        }
    }
}
