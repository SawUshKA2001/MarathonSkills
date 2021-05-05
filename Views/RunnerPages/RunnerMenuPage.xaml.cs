using System.Windows;
using System.Windows.Controls;

namespace MarathonSkills.Views.RunnerPages
{
    /// <summary>
    /// Логика взаимодействия для RunnerMenuPage.xaml
    /// </summary>
    public partial class RunnerMenuPage : Page
    {
        public RunnerMenuPage()
        {
            InitializeComponent();
        }

        private void ContactsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ContactsPage());
        }

        private void MarathonRegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RunnerMarathonRegisrtration());
        }

        private void EditProfileButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RunnerEditProfilePage());
        }

        private void MyResultsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RunnerResultsPage());
        }

        private void MyCharityButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new RunnerCharityPage());
        }
    }
}
