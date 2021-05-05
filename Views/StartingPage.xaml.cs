using MarathonSkills.Controllers;
using System.Windows;
using System.Windows.Controls;

namespace MarathonSkills.Views
{
    /// <summary>
    /// Логика взаимодействия для StartingPage.xaml
    /// </summary>
    public partial class StartingPage : Page
    {
        readonly MarathonsController marathonObj = new MarathonsController();
        /// <summary>
        /// Инициализация страницы StartingPage
        /// </summary>
        public StartingPage()
        {
            InitializeComponent();

            MarathonNameLabel.Content = marathonObj.GetCurrentMarathonInfo().YearName;
            MarathonInfoTextBlock.Text = marathonObj.GetCurrentMarathonInfo().countries.country_name + ", " + marathonObj.GetCurrentMarathonInfo().marathon_city_name;
        }

        private void AuthButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new NavigationPage("Авторизация"));
        }

        private void RunnerButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new NavigationPage("Стать бегуном"));
        }

        private void DonateButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new NavigationPage("Пожертвование"));
        }

        private void ViewerButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new NavigationPage("Стать зрителем"));
        }

        private void MoreAboutButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new NavigationPage("Узнать больше"));
        }
    }
}
