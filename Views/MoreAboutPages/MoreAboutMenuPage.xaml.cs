using System.Windows;
using System.Windows.Controls;

namespace MarathonSkills.Views.MoreAboutPages
{
    /// <summary>
    /// Логика взаимодействия для MoreAboutMenuPage.xaml
    /// </summary>
    public partial class MoreAboutMenuPage : Page
    {
        public MoreAboutMenuPage()
        {
            InitializeComponent();
        }

        private void BMICalculatorButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new BmiCalculatorPage());
        }

        private void EventResultsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MoreAboutEventResultsPage());
        }

        private void CheritiesButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new MoreAboutCharitiesPage());
        }
    }
}
