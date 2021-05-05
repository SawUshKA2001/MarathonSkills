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
        readonly RolesController roleObj = new RolesController();
        readonly UsersController userObj = new UsersController();
        readonly RunnersController runObj = new RunnersController();
        /// <summary>
        /// Инициализация элементов страницы AdminUsersPage
        /// </summary>
        public AdminUsersPage()
        {
            InitializeComponent();
            RoleComboBox.ItemsSource = roleObj.GetRoles().Where(x=>x.role_id!=1);
            RoleComboBox.SelectedValuePath = "role_id";
            RoleComboBox.DisplayMemberPath = "role_name";
            RoleComboBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Нажатие на кнопку изменения  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Действие на изменение значения RoleComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RoleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UsersDataGrid.ItemsSource = userObj.GetUsersByRole(Convert.ToInt32(RoleComboBox.SelectedValue));
        }

        /// <summary>
        /// Нажатие на кнопку добавления нового пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminAddNewUserPage());
        }
    }
}
