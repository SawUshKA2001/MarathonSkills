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
    /// Логика взаимодействия для AdminCharitiesPage.xaml
    /// </summary>
    public partial class AdminCharitiesPage : Page
    {
        CharitiesController charObj = new CharitiesController();
        FileManagerClass fileObj = new FileManagerClass();
        /// <summary>
        /// Инициализация объектов страницы AdminCharitiesPage
        /// </summary>
        public AdminCharitiesPage()
        {
            InitializeComponent();
            charObj = new CharitiesController();
            CharitiesDataGrid.ItemsSource = charObj.GetCharities();
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            this.NavigationService.Navigate(new AdminEditCharityPage(button.DataContext as Models.charities));
        }

        private void AddCharityButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new AdminAddCharity());
        }

        private void SaveToFileButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dictionary<string, List<string>> currentLoadableData = new Dictionary<string, List<string>>();
                currentLoadableData.Add("Название", new List<string>());
                currentLoadableData.Add("Описание", new List<string>());
                foreach (var item in charObj.GetCharities())
                {
                    currentLoadableData["Название"].Add(item.charity_name);
                    currentLoadableData["Описание"].Add(item.charity_description);
                }

                if (fileObj.DownLoadToCsvFile(currentLoadableData))
                {
                    MessageBox.Show("Сохранение прошло успешно!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
