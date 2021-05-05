using System.Windows.Controls;

namespace MarathonSkills.Views.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для AdminMenuPage.xaml
    /// </summary>
    public partial class AdminMenuPage : Page
    {
        public AdminMenuPage()
        {
            InitializeComponent();
        }

        private void UsersButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminUsersPage());
        }

        private void CharitiesButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {

        }
    }
}
