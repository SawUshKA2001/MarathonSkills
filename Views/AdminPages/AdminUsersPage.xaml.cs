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
using MarathonSkills.Controllers;

namespace MarathonSkills.Views.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для AdminUsersPage.xaml
    /// </summary>
    public partial class AdminUsersPage : Page
    {
        RolesController roleObj = new RolesController();
        UsersController userObj = new UsersController();
        RunnersController runObj = new RunnersController();
        public AdminUsersPage()
        {
            InitializeComponent();
            RoleComboBox.ItemsSource = roleObj.GetRoles().Where(x=>x.role_id!=1);
            RoleComboBox.SelectedValuePath = "role_id";
            RoleComboBox.DisplayMemberPath = "role_name";
            RoleComboBox.SelectedIndex = 0;
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            Models.users currentUser = button.DataContext as Models.users;
            if(currentUser.role_id == 3)
            {
                this.NavigationService.Navigate(new AdminRunnerEditPage(currentUser, runObj.GetRunnerInfo(runObj.GetRunnerId(currentUser.user_id))));
            }
            else
            {
                this.NavigationService.Navigate(new AdminUserEditPage(currentUser));
            }
        }

        private void RoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UsersDataGrid.ItemsSource = userObj.GetUsersByRole(Convert.ToInt32(RoleComboBox.SelectedValue));
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminAddNewUserPage());
        }
    }
}
