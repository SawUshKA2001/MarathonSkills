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

namespace MarathonSkills.Views.CoordinatorPages
{
    /// <summary>
    /// Логика взаимодействия для CoordinatorRunnersPage.xaml
    /// </summary>
    public partial class CoordinatorRunnersPage : Page
    {
        RunnersController runObj = new RunnersController();
        FileManagerClass fileObj = new FileManagerClass();
        List<Models.runners> currentRunners;
        public CoordinatorRunnersPage()
        {
            InitializeComponent();
            runObj = new RunnersController();
            currentRunners = runObj.GetRunners();
            RunnersDataGrid.ItemsSource = currentRunners;

        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CoordinatorEditRunnerPage((sender as Button).DataContext as Models.runners));
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new CoordinatorAddRunnerPage());
        }

        private void DownLoadButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dictionary<string, List<string>> currentLoadableData = new Dictionary<string, List<string>>();
                currentLoadableData.Add("Email", new List<string>());
                currentLoadableData.Add("Фамилия", new List<string>());
                currentLoadableData.Add("Имя", new List<string>());
                currentLoadableData.Add("Отчество", new List<string>());
                currentLoadableData.Add("Пол", new List<string>());
                currentLoadableData.Add("Дата рождения", new List<string>());
                currentLoadableData.Add("Страна", new List<string>());
                currentLoadableData.Add("Благотворительность", new List<string>());
                foreach (var item in currentRunners)
                {
                    currentLoadableData["Email"].Add(item.users.user_email);
                    currentLoadableData["Фамилия"].Add(item.users.user_lastname);
                    currentLoadableData["Имя"].Add(item.users.user_firstname);
                    currentLoadableData["Отчество"].Add(item.users.user_othername);
                    currentLoadableData["Пол"].Add(item.users.genders.gender_name);
                    currentLoadableData["Дата рождения"].Add(item.runner_birthdate.ToString("d"));
                    currentLoadableData["Страна"].Add(item.countries.country_name);
                    currentLoadableData["Благотворительность"].Add(item.charities.charity_name);
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
