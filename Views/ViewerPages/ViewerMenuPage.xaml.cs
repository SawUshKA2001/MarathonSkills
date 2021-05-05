using System.Windows;
using System.Windows.Controls;

namespace MarathonSkills.Views.ViewerPages
{
    /// <summary>
    /// Логика взаимодействия для ViewerMenuPage.xaml
    /// </summary>
    public partial class ViewerMenuPage : Page
    {
        /// <summary>
        /// Инициализация страницы ViewerMenuPage
        /// </summary>
        public ViewerMenuPage()
        {
            InitializeComponent();
        }

        private void AddReviewButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ViewerAddReviewPage());
        }

        private void SeeReviewsButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new ViewerSeeReviewsPage());
        }
    }
}
