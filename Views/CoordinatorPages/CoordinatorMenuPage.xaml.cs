using System.Windows.Controls;

namespace MarathonSkills.Views.CoordinatorPages
{
    /// <summary>
    /// Логика взаимодействия для CoordinatorMenuPage.xaml
    /// </summary>
    public partial class CoordinatorMenuPage : Page
    {
        /// <summary>
        /// Инициализация объектов страницы CoordinatorMenuPage
        /// </summary>
        public CoordinatorMenuPage()
        {
            InitializeComponent();
        }

        private void RunnersButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CoordinatorRunnersPage());
        }

        private void CharitiesButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminPages.AdminCharitiesPage());
        }
    }
}
