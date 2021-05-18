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
    /// Логика взаимодействия для VolunteersPage.xaml
    /// </summary>
    public partial class VolunteersPage : Page
    {
        List<Models.volunteers> currentVolunteers;
        FileManagerClass fileObj = new FileManagerClass();
        /// <summary>
        /// Инициализация страницы VolunteersPage
        /// </summary>
        public VolunteersPage()
        {
            VolunteersController volObj = new VolunteersController();
            InitializeComponent();
            currentVolunteers = volObj.GetVolunteers();
            VolunteersDataGrid.ItemsSource = currentVolunteers;
        }

        /// <summary>
        /// Нажатие на кнопку изменения волонтёра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
             this.NavigationService.Navigate(new AdminEditVolunteerPage((sender as Button).DataContext as Models.volunteers));
        }

        /// <summary>
        /// Нажатие на кнопку добавления волонтёра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddVolunteerButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminAddVolunteerPage());
        }

        /// <summary>
        /// Нажатие на кнопку выгрузки данных о волонтёрах в CSV файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DownloadVolunteersButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dictionary<string, List<string>> currentLoadableData = new Dictionary<string, List<string>>();
                currentLoadableData.Add("Фамилия", new List<string>());
                currentLoadableData.Add("Имя", new List<string>());
                currentLoadableData.Add("Отчество", new List<string>());
                currentLoadableData.Add("Дата рождения", new List<string>());
                currentLoadableData.Add("Пол", new List<string>());
                currentLoadableData.Add("Страна", new List<string>());
                foreach (var item in currentVolunteers)
                {
                    currentLoadableData["Фамилия"].Add(item.volunteer_lastname);
                    currentLoadableData["Имя"].Add(item.volunteer_firstname);
                    currentLoadableData["Отчество"].Add(item.volunteer_othername);
                    currentLoadableData["Дата рождения"].Add(item.volunteer_birthdate.ToString("D"));
                    currentLoadableData["Пол"].Add(item.genders.gender_name);
                    currentLoadableData["Страна"].Add(item.countries.country_name);
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
