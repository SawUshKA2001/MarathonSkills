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
using MarathonSkillsLibrary;

namespace MarathonSkills.Views.AdminPages
{
    /// <summary>
    /// Логика взаимодействия для AdminUsersPage.xaml
    /// </summary>
    public partial class AdminUsersPage : Page
    {
        readonly RolesController roleObj = new RolesController();
        UsersController userObj = new UsersController();
        readonly RunnersController runObj = new RunnersController();
        List<Models.users> currentUsers;
        FileManagerClass fileObj = new FileManagerClass();
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
            userObj = new UsersController();
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
            userObj = new UsersController();
            currentUsers = userObj.GetUsersByRole(Convert.ToInt32(RoleComboBox.SelectedValue));
            UsersDataGrid.ItemsSource = currentUsers;
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

        private void DownloadUserButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dictionary<string, List<string>> currentLoadableData = new Dictionary<string, List<string>>();
                currentLoadableData.Add("Email", new List<string>());
                currentLoadableData.Add("Пароль", new List<string>());
                currentLoadableData.Add("Фамилия", new List<string>());
                currentLoadableData.Add("Имя", new List<string>());
                currentLoadableData.Add("Отчество", new List<string>());
                currentLoadableData.Add("Роль", new List<string>());
                currentLoadableData.Add("Пол", new List<string>());
                foreach (var item in currentUsers)
                {
                    currentLoadableData["Email"].Add(item.user_email);
                    currentLoadableData["Пароль"].Add(item.user_password);
                    currentLoadableData["Фамилия"].Add(item.user_lastname);
                    currentLoadableData["Имя"].Add(item.user_firstname);
                    currentLoadableData["Отчество"].Add(item.user_othername);
                    currentLoadableData["Роль"].Add(item.roles.role_name);
                    currentLoadableData["Пол"].Add(item.genders.gender_name);
                }

                if (fileObj.DownLoadToCsvFile(currentLoadableData))
                {
                    MessageBox.Show("Сохранение прошло успешно!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
