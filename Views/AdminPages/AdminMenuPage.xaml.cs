using System.Windows.Controls;

namespace MarathonSkills.Views.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для AdminMenuPage.xaml
    /// </summary>
    public partial class AdminMenuPage : Page
    {
        /// <summary>
        /// Инициализация элементов страницы AdminMenuPage
        /// </summary>
        public AdminMenuPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Нажатие на кнопку пользователи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsersButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminUsersPage());
        }

        /// <summary>
        /// Нажатие на кнопку Благотворительные организации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CharitiesButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminCharitiesPage());
        }

        private void VolunteersButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new VolunteersPage());
        }
    }
}
